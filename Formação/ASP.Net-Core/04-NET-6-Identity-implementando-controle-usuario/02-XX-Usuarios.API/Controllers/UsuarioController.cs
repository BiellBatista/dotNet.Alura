using _02_XX_Usuarios.API.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace _02_XX_Usuarios.API.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    [HttpPost]
    public IActionResult CadastraUsuario(CreateUsuarioDto dto)
    {
        throw new NotImplementedException();
    }
}