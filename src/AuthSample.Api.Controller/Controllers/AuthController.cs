namespace AuthSample.Api.Controller.Controllers;

[AllowAnonymous]
[ApiController]
[Route("[controller]")]
public class AuthController(ITokenManager tokenManager) : ControllerBase
{
    private readonly ITokenManager _tokenManager = tokenManager;

    [HttpPost("token")]
    [ProducesResponseType<LoginResponse>(StatusCodes.Status200OK)]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if(string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        {
            return BadRequest("Prencha os campos");
        }

        var user = AuthAppContext.Usuarios
            .FirstOrDefault(x => x.Email.Equals(request.Email) && 
                                 x.Senha.Equals(request.Password));

        if(user is null)
        {
            return BadRequest("Usuario ou Senha invalidos");
        }
        var token = _tokenManager.GenerateToken(user);
        var refreshToken = _tokenManager.GenerateRefreshToken(user);

        var result = new LoginResponse(token, refreshToken);

        return Ok(result);
    }

    [HttpPost("refreshtoken")]
    public async Task<IActionResult> LoginRefresh([FromBody] RefreshRequest request)
    {
        if(string.IsNullOrEmpty(request.RefreshToken))
        {
            return BadRequest();
        }

        var (isValid, email) = await _tokenManager.ValidateTokenAsync(request.RefreshToken);

        if(!isValid)
        {
            return Unauthorized();
        }

        var userEmail = AuthAppContext.Usuarios
            .FirstOrDefault(x => x.Email.Equals(email));

        if(userEmail is null)
        {
            return Unauthorized();
        }

        var token = _tokenManager.GenerateToken(userEmail!);
        var refreshToken = _tokenManager.GenerateRefreshToken(userEmail!);

        return Ok(new LoginResponse(token, refreshToken));
    }
}

public record LoginRequest(string Email, string Password);
public record LoginResponse(string Token, string RefreshToken);
public record RefreshRequest(string RefreshToken);