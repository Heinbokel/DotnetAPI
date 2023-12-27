using DotnetAPI.Models;
using DotnetAPI.Models.Requests;
using DotnetAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthController : ControllerBase
{

    public HealthController() {
        
    }

    [HttpGet("", Name = "Health")]
    public IActionResult GetHealth()
    {
        return Ok(new {
            Health = "GOOD"
        });
    }

}
