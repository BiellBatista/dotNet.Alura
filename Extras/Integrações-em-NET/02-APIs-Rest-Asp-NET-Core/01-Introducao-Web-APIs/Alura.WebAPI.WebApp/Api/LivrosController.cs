using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alura.ListaLeitura.Modelos;
using Alura.ListaLeitura.Persistencia;
using Microsoft.AspNetCore.Mvc;

namespace Alura.WebAPI.WebApp.Api
{
    [ApiController] //todo controller que serve uma API deve ter esta anotação
    [Route("[controller]")] //quando coloco a anotação de cima, devo usar esta, obrigatóriamente. Como ele está em cima, irá afetar todas as actions (métodos públicos) desta classe
    public class LivrosController : ControllerBase //Esta classe Base não possui suporte a view
    {
        private readonly IRepository<Livro> _repo;

        public LivrosController(IRepository<Livro> repository)
        {
            _repo = repository;
        }

        [HttpGet("{id}")]
        public IActionResult Recuperar(int id)
        {
            var model = _repo.Find(id);
            if (model is null)
                return NotFound();
            return Ok(model.ToModel());
        }

        [HttpPost]
        public IActionResult Incluir([FromBody] LivroUpload model)
        {
            if (ModelState.IsValid)
            {
                var livro = model.ToLivro();
                _repo.Incluir(livro);

                var uri = Url.Action("Recuperar", new { id = livro.Id }); //criando uma URL a partir de uma action de um controler. O primeiro argumento é a action e o segundo é o identificador do objeto na base de dados

                return Created(uri, livro); //código 201
                /**
                 * Retornando um objeto, após a conclusão de sua operação
                 */
            }

            return BadRequest(); //requisição inválida (error 400)
        }

        [HttpPut]
        //a tag FromBody é para indicar que o parâmetro vem no body da requisição e não na URL. Com isso, eu evito o problema do BadRequest
        //Existe outras tagm além do FromBody
        public IActionResult Alterar([FromBody] LivroUpload model)
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
                return Ok(); //código 200
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
            return NoContent(); //OK, mas não tem nenhum conteúdo (código 204)
        }
    }
}

/*
 * Created() --> 201
 * Ok() --> 200
 * BadRequest() --> 400
 * NoContent() --> 204
 */
