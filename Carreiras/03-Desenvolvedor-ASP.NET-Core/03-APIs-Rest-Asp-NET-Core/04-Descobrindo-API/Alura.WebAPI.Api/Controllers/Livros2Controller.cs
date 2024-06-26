﻿using Alura.ListaLeitura.Modelos;
using Alura.ListaLeitura.Persistencia;
using Alura.WebAPI.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Alura.WebAPI.Api.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("2.0")]
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/v{version:apiVersion}/livros")]
    public class Livros2Controller : ControllerBase
    {
        private readonly IRepository<Livro> _repo;

        public Livros2Controller(IRepository<Livro> repository)
        {
            _repo = repository;
        }

        [HttpGet]
        public IActionResult ListaDeLivros(
            [FromQuery] LivroPaginacao paginacao)
        {
            var livroPaginado = _repo.All
                .Select(l => l.ToApi())
                .ToLivroPaginado(paginacao);

            return Ok(livroPaginado);
        }

        [HttpGet("{id}")]
        public IActionResult Recuperar(int id)
        {
            var model = _repo.Find(id);
            if (model is null)
                return NotFound();
            return Ok(model);
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
        public IActionResult Incluir([FromForm] LivroUpload model)

        {
            if (ModelState.IsValid)
            {
                var livro = model.ToLivro();

                //try
                //{
                _repo.Incluir(livro);
                //}
                //catch (System.Exception e)
                //{
                //    var errorResponse = ErroResponse.From(e);
                //    return StatusCode(500, errorResponse);
                //}

                var uri = Url.Action("Recuperar", new { id = livro.Id });

                return Created(uri, livro);
            }

            return BadRequest(ErroResponse.FromModelState(ModelState));
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
