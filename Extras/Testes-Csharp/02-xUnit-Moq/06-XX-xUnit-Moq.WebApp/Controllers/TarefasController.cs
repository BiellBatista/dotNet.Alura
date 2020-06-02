using Microsoft.AspNetCore.Mvc;
using _06_XX_xUnit_Moq.WebApp.Models;
using _06_XX_xUnit_Moq.Core.Commands;
using _06_XX_xUnit_Moq.Services.Handlers;
using _06_XX_xUnit_Moq.Infrastructure;
using Microsoft.Extensions.Logging;

namespace _06_XX_xUnit_Moq.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        IRepositorioTarefas _repo;
        ILogger<CadastraTarefaHandler> _logger;

        public TarefasController(IRepositorioTarefas repo, ILogger<CadastraTarefaHandler> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult EndpointCadastraTarefa(CadastraTarefaVM model)
        {
            var cmdObtemCateg = new ObtemCategoriaPorId(model.IdCategoria);
            var categoria = new ObtemCategoriaPorIdHandler(_repo).Execute(cmdObtemCateg);
            if (categoria == null)
            {
                return NotFound("Categoria não encontrada");
            }

            var comando = new CadastraTarefa(model.Titulo, categoria, model.Prazo);
            var handler = new CadastraTarefaHandler(_repo, _logger);
            handler.Execute(comando);
            return Ok();
        }
    }
}