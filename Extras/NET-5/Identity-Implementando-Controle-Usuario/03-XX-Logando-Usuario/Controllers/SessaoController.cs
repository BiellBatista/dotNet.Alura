using _03_XX_Logando_Usuario.Data.Dtos.Sessao;
using _03_XX_Logando_Usuario.Services;
using Microsoft.AspNetCore.Mvc;

namespace _03_XX_Logando_Usuario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private SessaoService _sessaoService;

        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDto dto)
        {
            ReadSessaoDto readDto = _sessaoService.AdicionaSessao(dto);

            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = readDto.SessaoId }, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessoesPorId(int id)
        {
            ReadSessaoDto readDto = _sessaoService.RecuperaSessoesPorId(id);

            if (readDto is null) return NotFound();

            return Ok(readDto);
        }
    }
}