using _04_XX_Relacionamento_N_N.Data;
using _04_XX_Relacionamento_N_N.Data.Dtos.Sessao;
using _04_XX_Relacionamento_N_N.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace _04_XX_Relacionamento_N_N.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private IMapper _mapper;

        private AppDbContext _context;

        public SessaoController(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);

            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = sessao.Id }, sessao);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessoesPorId(int id)
        {
            var sessao = _context.Sessoes.FirstOrDefault(f => f.Id == id);

            if (sessao is not null)
            {
                var sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

                return Ok(sessaoDto);
            }

            return NotFound();
        }
    }
}