using _02_XX_Conhecendo_Identity.Data.Dtos.Cinema;
using _02_XX_Conhecendo_Identity.Services;
using Microsoft.AspNetCore.Mvc;

namespace _02_XX_Conhecendo_Identity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            var readDto = _cinemaService.AdicionaCinema(cinemaDto);

            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaCinemas([FromQuery] string nomeDoFilme)
        {
            var readDto = _cinemaService.RecuperaCinemas(nomeDoFilme);

            if (readDto is null) return NotFound();

            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId(int id)
        {
            var readDto = _cinemaService.RecuperaCinemasPorId(id);

            if (readDto is null) return NotFound();

            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            var resultado = _cinemaService.AtualizaCinema(id, cinemaDto);

            if (resultado.IsFailed) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            var resultado = _cinemaService.DeletaCinema(id);

            if (resultado.IsFailed) return NotFound();

            return NoContent();
        }
    }
}