using Microsoft.AspNetCore.Mvc;

namespace AuthSample.Api.Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType<AuthResponse>(StatusCodes.Status200OK)]
    public IActionResult Authenticate([FromBody] AuthRequest authRequest)
    {
        return Ok(new { authRequest.Email, authRequest.Password });
    }
}

public record AuthRequest(string Email, string Password);

public record AuthResponse(string Token);
