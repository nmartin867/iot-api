using IotApi.Model;
using IotApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace IotApi.Controllers;


[Route("[controller]")]
[ApiController]
public class AuthenticationController: ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    
    [HttpPost]
    public IActionResult Login([FromBody] Login user)
    {
        if (user.UserName is null || user.Password is null)
        {
            return BadRequest();
        }
        return Unauthorized();
    }
}