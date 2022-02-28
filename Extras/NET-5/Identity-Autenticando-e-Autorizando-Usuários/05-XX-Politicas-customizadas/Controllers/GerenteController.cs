using _05_XX_Politicas_customizadas.Data.Dtos.Gerente;
using _05_XX_Politicas_customizadas.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace _05_XX_Politicas_customizadas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpPost]
        public IActionResult AdicionaGerente(CreateGerenteDto dto)
        {
            ReadGerenteDto readDto = _gerenteService.AdicionaGerente(dto);
            return CreatedAtAction(nameof(RecuperaGerentesPorId), new { readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentesPorId(int id)
        {
            ReadGerenteDto readDto = _gerenteService.RecuperaGerentesPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            Result resultado = _gerenteService.DeleteGerente(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}