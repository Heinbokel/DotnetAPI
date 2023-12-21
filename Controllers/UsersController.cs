using DotnetAPI.Models;
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

}
