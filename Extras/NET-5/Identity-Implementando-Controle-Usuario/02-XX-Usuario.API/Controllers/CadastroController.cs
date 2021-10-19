using _02_XX_Usuario.API.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace _02_XX_Usuario.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto createDto)
        {
            return Ok();
        }
    }
}