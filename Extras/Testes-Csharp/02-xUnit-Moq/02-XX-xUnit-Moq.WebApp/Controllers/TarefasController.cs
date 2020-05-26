using Microsoft.AspNetCore.Mvc;
using _02_XX_xUnit_Moq.WebApp.Models;
using _02_XX_xUnit_Moq.Core.Commands;
using _02_XX_xUnit_Moq.Services.Handlers;

namespace _02_XX_xUnit_Moq.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        [HttpPost]
        public IActionResult EndpointCadastraTarefa(CadastraTarefaVM model)
        {
            var cmdObtemCateg = new ObtemCategoriaPorId(model.IdCategoria);
            var categoria = new ObtemCategoriaPorIdHandler().Execute(cmdObtemCateg);
            if (categoria == null)
            {
                return NotFound("Categoria não encontrada");
            }

            var comando = new CadastraTarefa(model.Titulo, categoria, model.Prazo);
            //var handler = new CadastraTarefaHandler();
            //handler.Execute(comando);
            return Ok();
        }
    }
}