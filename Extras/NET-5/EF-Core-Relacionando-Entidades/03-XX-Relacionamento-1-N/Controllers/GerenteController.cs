using _03_XX_Relacionamento_1_N.Data;
using _03_XX_Relacionamento_1_N.Data.Dtos.Gerente;
using _03_XX_Relacionamento_1_N.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace _03_XX_Relacionamento_1_N.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private IMapper _mapper;

        private AppDbContext _context;

        public GerenteController(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaGerente([FromBody] CreateGerenteDto gerenteDto)
        {
            var gerente = _mapper.Map<Gerente>(gerenteDto);

            _context.Gerentes.Add(gerente);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperaGerentesPorId), new { Id = gerente.Id }, gerente);
        }

        [HttpGet]
        public IEnumerable<Gerente> RecuperaGerentes()
        {
            return _context.Gerentes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaGerentesPorId(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(f => f.Id == id);

            if (gerente is not null)
            {
                var gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);

                return Ok(gerenteDto);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(g => g.Id == id);

            if (gerente is null) return NotFound();

            _context.Remove(gerente);
            _context.SaveChanges();

            return NoContent();
        }
    }
}