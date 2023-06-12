using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _04_XX_Usuarios.API.Controllers;

[ApiController]
[Route("[Controller]")]
public class AcessoController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "IdadeMinima")]
    public IActionResult Get()
    {
        return Ok("Acesso permitido!");
    }
}