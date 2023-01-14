namespace asset.api.Services.User;

public interface IUserService
{
    Task<List<Entities.User>> GetUsersAsync();
}