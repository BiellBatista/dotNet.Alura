using _01_XX_Arrumando_Codigo.Data;
using _01_XX_Arrumando_Codigo.Data.Dtos.Sessao;
using _01_XX_Arrumando_Codigo.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace _01_XX_Arrumando_Codigo.Controllers
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