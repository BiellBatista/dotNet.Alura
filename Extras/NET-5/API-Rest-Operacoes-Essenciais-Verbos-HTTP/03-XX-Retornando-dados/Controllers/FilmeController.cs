using _03_XX_Retornando_dados.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace _03_XX_Retornando_dados.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);

            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperaFilmes()
        {
            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            var filme = filmes.FirstOrDefault(f => f.Id == id);

            if (filme is not null) return Ok(filme);

            return NotFound();
        }
    }
}