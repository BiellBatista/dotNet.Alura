using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _02_02_XX_Responsabilidade_Unica.WebApp.Models;
using _02_02_XX_Responsabilidade_Unica.WebApp.Dados;

namespace _02_02_XX_Responsabilidade_Unica.WebApp.Controllers
{
    [ApiController]
    [Route("/api/leiloes")]
    public class LeilaoApiController : ControllerBase
    {
        AppDbContext _context;

        public LeilaoApiController()
        {
            _context = new AppDbContext();
        }

        [HttpGet]
        public IActionResult EndpointGetLeiloes()
        {
            var leiloes = _context.Leiloes
                .Include(l => l.Categoria);
            return Ok(leiloes);
        }

        [HttpGet("{id}")]
        public IActionResult EndpointGetLeilaoById(int id)
        {
            var leilao = _context.Leiloes.Find(id);
            if (leilao == null)
            {
                return NotFound();
            }
            return Ok(leilao);
        }

        [HttpPost]
        public IActionResult EndpointPostLeilao(Leilao leilao)
        {
            _context.Leiloes.Add(leilao);
            _context.SaveChanges();
            return Ok(leilao);
        }

        [HttpPut]
        public IActionResult EndpointPutLeilao(Leilao leilao)
        {
            _context.Leiloes.Update(leilao);
            _context.SaveChanges();
            return Ok(leilao);
        }

        [HttpDelete("{id}")]
        public IActionResult EndpointDeleteLeilao(int id)
        {
            var leilao = _context.Leiloes.Find(id);
            if (leilao == null)
            {
                return NotFound();
            }
            _context.Leiloes.Remove(leilao);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
