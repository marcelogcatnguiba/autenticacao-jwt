using Microsoft.AspNetCore.Mvc;

namespace AuthSample.Api.Controller.Controllers;

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
