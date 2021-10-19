using _05_XX_Usuario.API.Data.Dtos;
using _05_XX_Usuario.API.Data.Requests;
using _05_XX_Usuario.API.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace _05_XX_Usuario.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private CadastroService _cadastroService;

        public CadastroController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto createDto)
        {
            Result resultado = _cadastroService.CadastraUsuario(createDto);

            if (resultado.IsFailed) return StatusCode(500);

            return Ok(resultado.Successes);
        }

        [HttpPost("/ativa")]
        public IActionResult AtivaContaUsuario(AtivaContaRequest request)
        {
            Result resultado = _cadastroService.AtivaUsuario(request);

            if (resultado.IsFailed) return StatusCode(500);

            return Ok(resultado.Successes);
        }
    }
}