namespace AuthSample.Api.Controller.Controllers;

[Authorize(Roles = Usuario.Administrador)]
[ApiController]
[Route("[controller]")]
[ProducesResponseType<WelcomeMessage>(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Welcome()
    {
        return Ok(new WelcomeMessage("Bem vindo"));
    }
}

public record WelcomeMessage(string Message);