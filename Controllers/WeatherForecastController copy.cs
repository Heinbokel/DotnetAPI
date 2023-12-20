using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    public UserController() {

    }


    [HttpGet("test/{testValue}", Name = "Test")]
    public string[] Test(string testValue, [FromQuery] string fromQuery1)
    {
        return new string[]{
            testValue, fromQuery1
        };
    }

}
