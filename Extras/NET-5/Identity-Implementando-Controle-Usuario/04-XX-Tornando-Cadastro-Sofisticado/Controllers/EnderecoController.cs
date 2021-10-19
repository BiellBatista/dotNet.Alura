using _04_XX_Tornando_Cadastro_Sofisticado.Data.Dtos.Endereco;
using _04_XX_Tornando_Cadastro_Sofisticado.Services;
using Microsoft.AspNetCore.Mvc;

namespace _04_XX_Tornando_Cadastro_Sofisticado.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            var readDto = _enderecoService.AdicionaEndereco(enderecoDto);

            return CreatedAtAction(nameof(RecuperaEnderecosPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaEnderecos()
        {
            var readDto = _enderecoService.RecuperaEnderecos();

            if (readDto is null) return NotFound();

            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecosPorId(int id)
        {
            var readDto = _enderecoService.RecuperaEnderecosPorId(id);

            if (readDto is null) return NotFound();

            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            var resultado = _enderecoService.AtualizaEndereco(id, enderecoDto);

            if (resultado.IsFailed) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            var resultado = _enderecoService.DeletaEndereco(id);

            if (resultado.IsFailed) return NotFound();

            return NoContent();
        }
    }
}