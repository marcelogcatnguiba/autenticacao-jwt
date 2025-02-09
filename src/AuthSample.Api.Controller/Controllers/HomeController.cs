using AuthSample.Api.Controller.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthSample.Api.Controller.Controllers;

[Authorize(Roles = AuthAppContext.ROLE_ADMIN)]
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
