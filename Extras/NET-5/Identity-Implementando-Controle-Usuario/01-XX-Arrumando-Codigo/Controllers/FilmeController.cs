using _01_XX_Arrumando_Codigo.Data.Dtos.Filme;
using _01_XX_Arrumando_Codigo.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace _01_XX_Arrumando_Codigo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;

        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            var filme = _filmeService.AdicionaFilme(filmeDto);

            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperaFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            var readDto = _filmeService.RecuperaFilmes(classificacaoEtaria);

            if (readDto is not null)
                return Ok(readDto);

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            var readDto = _filmeService.RecuperaFilmesPorId(id);

            if (readDto is not null)
                return Ok(readDto);

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Result resultado = _filmeService.AtualizaFilme(id, filmeDto);

            if (resultado.IsFailed)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Result resultado = _filmeService.DeletaFilme(id);

            if (resultado.IsFailed)
                return NotFound();

            return NoContent();
        }
    }
}