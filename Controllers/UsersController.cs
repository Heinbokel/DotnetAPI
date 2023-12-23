using DotnetAPI.Models;
using DotnetAPI.Models.Requests;
using DotnetAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{

    private IUserService _userService;

    public UsersController(IUserService userService) {
        this._userService = userService;
    }

    [HttpGet("Users/{UserId}", Name = "User")]
    public User GetUser(int UserId)
    {
        return _userService.GetUser(UserId);
    }


    [HttpGet("", Name = "Users")]
    public List<User> GetUsers()
    {
        return _userService.GetUsers();
    }

    [HttpPost("", Name = "CreateUser")]
    public IActionResult CreateUser(CreateUserRequest Request) {
        return Ok(_userService.CreateUser(Request));
    }

    [HttpPut("Users/{UserId}", Name = "UpdateUser")]
    public IActionResult UpdateUser(UpdateUserRequest Request, int UserId) {
        return Ok(_userService.UpdateUser(Request, UserId));
    }

}
