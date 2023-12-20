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


    [HttpGet("test/{testValue}", Name = "Test")]
    public string[] Test(string testValue, [FromQuery] string fromQuery1)
    {
        return _userService.GetAllUsers();
    }

}
