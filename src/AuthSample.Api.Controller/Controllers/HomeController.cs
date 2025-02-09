namespace AuthSample.Api.Controller.Controllers;

[Authorize(Roles = Usuario.Administrador)]
[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Welcome()
    {
        return Ok(new { message = "Bem vindo" });
    }
}
