using Microsoft.AspNetCore.Mvc;

namespace AuthSample.Api.Controller.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost]
    public IActionResult Authenticate([FromBody] AuthRequest authRequest)
    {
        return Ok(new { authRequest.Email, authRequest.Password });
    }
}

public record AuthRequest(string Email, string Password);

public record AuthResponse(string Token);
