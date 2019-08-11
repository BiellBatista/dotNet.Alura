using System.Linq;
using Alura.ListaLeitura.Modelos;
using Alura.ListaLeitura.Persistencia;
using Alura.WebAPI.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Alura.WebAPI.Api.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly IRepository<Livro> _repo;

        public LivrosController(IRepository<Livro> repository)
        {
            _repo = repository;
        }

        [HttpGet]
        public IActionResult ListaDeLivros()
        {
            var lista = _repo.All.Select(l => l.ToApi()).ToList();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        //Você também pode documentar quais os media-types que operação irá produzir.Essa info é bem importante para o dev que está consumindo sua api preparar adequadamente seu código.Para isso usamos outro argumento na anotação, o Produces, que espera um array de strings.
      [SwaggerOperation(Summary = "Recupera o livro identificado por seu {id}.",
            Tags = new[] { "Livros" }, //Com essa declaração de tags sua documentação agrupará as operações embaixo de cada tag.
            Produces = new[] { "application/json", "application/xml" })]
        /**
         * esses três metados indicam o retorno desta action
         */
        [ProducesResponseType(statusCode: 200, Type = typeof(LivroApi))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErroResponse))]
        [ProducesResponseType(statusCode: 404)]
        //Outra coisa importante é documentar os parâmetros esperados pelas operações, seus tipos e obrigatoriedade. Isso é feito com a anotação SwaggerParameter
        public IActionResult Recuperar([FromRoute] [SwaggerParameter("Tipo da lista a ser obtida.")] int id)
        {
            var model = _repo.Find(id);
            if (model is null)
                return NotFound();
            return Ok(model.ToApi());
        }

        [HttpGet("{id}/capa")]
        public IActionResult ImagemCapa(int id)
        {
            byte[] img = _repo.All
                .Where(l => l.Id == id)
                .Select(l => l.ImagemCapa)
                .FirstOrDefault();
            if (img != null)
            {
                return File(img, "image/png");
            }

            return File("~/images/capas/capa-vazia.png", "image/png");
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Registra novo livro na base.")] //adicionando um breve do resumo do que este endpoint faz
        public IActionResult Incluir([FromForm] LivroUpload model)

        {
            if (ModelState.IsValid)
            {
                var livro = model.ToLivro();
                _repo.Incluir(livro);

                var uri = Url.Action("Recuperar", new { id = livro.Id });

                return Created(uri, livro);
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Alterar([FromForm] LivroUpload model)

        {
            if (ModelState.IsValid)
            {
                var livro = model.ToLivro();
                if (model.Capa == null)
                {
                    livro.ImagemCapa = _repo.All
                        .Where(l => l.Id == livro.Id)
                        .Select(l => l.ImagemCapa)
                        .FirstOrDefault();
                }
                _repo.Alterar(livro);
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var model = _repo.Find(id);

            if (model == null)
            {
                return NotFound();
            }

            _repo.Excluir(model);
            return NoContent();
        }
    }
}
