using DotnetAPI.Models;
using DotnetAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private IUserService _userService;

    public UserController(IUserService userService) {
        this._userService = userService;
    }


    [HttpGet("", Name = "Users")]
    public List<User> GetUsers()
    {
        return _userService.GetUsers();
    }

}
