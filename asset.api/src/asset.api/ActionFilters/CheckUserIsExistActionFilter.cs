using asset.api.Services.User;
using Microsoft.AspNetCore.Mvc.Filters;

namespace asset.api.ActionFilters;

public class CheckUserIdIsExistActionFilter : IAsyncActionFilter
{
    private readonly IUserService _userService;

    public CheckUserIdIsExistActionFilter(IUserService userService)
    {
        _userService = userService;
    }
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var userId = context.HttpContext.Request.Headers["userId"];

        var users = await _userService.GetUsersAsync();

        var registeredUser = users.FirstOrDefault(x => x.Id == new Guid(userId));
        
        if (registeredUser is null)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }
        
        await next();
    }
}