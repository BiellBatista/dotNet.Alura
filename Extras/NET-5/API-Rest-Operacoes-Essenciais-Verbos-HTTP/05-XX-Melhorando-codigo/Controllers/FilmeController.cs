using _05_XX_Melhorando_codigo.Data;
using _05_XX_Melhorando_codigo.Data.Dtos;
using _05_XX_Melhorando_codigo.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace _05_XX_Melhorando_codigo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly FilmeContext _context;
        private readonly IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            var filme = _mapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperaFilmes()
        {
            return _context.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

            if (filme is not null)
            {
                var filmeDto = _mapper.Map<ReadFilmeDto>(filme);

                return Ok(filmeDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

            if (filme is null) return NotFound();

            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

            if (filme is null) return NotFound();

            _context.Remove(filme);
            _context.SaveChanges();

            return NoContent();
        }
    }
}