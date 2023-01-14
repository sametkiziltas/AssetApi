using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using user.api.Models;
using user.api.Models.Base;

namespace user.api.Controllers;

[Route("api/users")]
public class UserController : ControllerBase
{
    #region constructor

    public UserController()
    {
    }

    #endregion

    [HttpGet]
    [ProducesResponseType(typeof(BaseResponse<List<ResponseUser>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllUsers()
    {
        BaseResponse<List<ResponseUser>> response = new();
        
        List<ResponseUser> data = new()
        {
            new ResponseUser
            {
                Id = new Guid("3c177241-9484-4956-a604-99b166fbd443"),
                FirstName = "Samet",
                LastName = "Kızıltaş",
                Email = "samet-kiziltas@outlook.com",
                DateOfBirth = DateTime.Now.AddYears(-25),
                Phone = "905316810706"
            },
            new ResponseUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Ahmet",
                LastName = "AA",
                Email = "ahmet@outlook.com",
                DateOfBirth = DateTime.Now.AddYears(-25),
                Phone = "905316810706"
            },
            new ResponseUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Mehmet",
                LastName = "MM",
                Email = "mehmet@outlook.com",
                DateOfBirth = DateTime.Now.AddYears(-25),
                Phone = "905316810706"
            },
            new ResponseUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Ayşe",
                LastName = "AA",
                Email = "ayse@outlook.com",
                DateOfBirth = DateTime.Now.AddYears(-25),
                Phone = "905316810706"
            },
            new ResponseUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Fatma",
                LastName = "",
                Email = "fatma@outlook.com",
                DateOfBirth = DateTime.Now.AddYears(-25),
                Phone = "905316810706"
            },
            new ResponseUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Samet",
                LastName = "Kızıltaş",
                Email = "samet-kiziltas@outlook.com",
                DateOfBirth = DateTime.Now.AddYears(-25),
                Phone = "905316810706"
            },
            new ResponseUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Ahmet",
                LastName = "AA",
                Email = "ahmet@outlook.com",
                DateOfBirth = DateTime.Now.AddYears(-25),
                Phone = "905316810706"
            },
            new ResponseUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Mehmet",
                LastName = "MM",
                Email = "mehmet@outlook.com",
                DateOfBirth = DateTime.Now.AddYears(-25),
                Phone = "905316810706"
            },
            new ResponseUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Ayşe",
                LastName = "AA",
                Email = "ayse@outlook.com",
                DateOfBirth = DateTime.Now.AddYears(-25),
                Phone = "905316810706"
            },
            new ResponseUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Fatma",
                LastName = "",
                Email = "fatma@outlook.com",
                DateOfBirth = DateTime.Now.AddYears(-25),
                Phone = "905316810706"
            }
        };
        
        return Ok(response.SetData(data));
    }
}