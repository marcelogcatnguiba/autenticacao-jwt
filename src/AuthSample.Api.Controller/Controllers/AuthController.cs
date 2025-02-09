namespace AuthSample.Api.Controller.Controllers;

[AllowAnonymous]
[ApiController]
[Route("[controller]")]
public class AuthController(ITokenManager tokenManager) : ControllerBase
{
    private readonly ITokenManager _tokenManager = tokenManager;

    [HttpPost]
    [ProducesResponseType<LoginResponse>(StatusCodes.Status200OK)]
    public IActionResult Authenticate([FromBody] LoginRequest request)
    {
        // Verificar se esta preenchido os campos
        if(string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        {
            return BadRequest("Prencha os campos");
        }

        //Buscar no banco de dados o usuario
        var user = AuthAppContext.Usuarios
            .FirstOrDefault(x => x.Email.Equals(request.Email) && 
                                 x.Senha.Equals(request.Password));

        if(user is null)
        {
            return BadRequest("Usuario ou Senha invalidos");
        }

        var result = new LoginResponse(_tokenManager.GenerateToken(user));

        return Ok(result);
    }
}

public record LoginRequest(string Email, string Password);
public record LoginResponse(string Token);