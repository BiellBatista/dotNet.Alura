﻿using Microsoft.AspNetCore.Mvc;
using _02_03_XX_Inversao_Dependencias.WebApp.Models;
using _02_03_XX_Inversao_Dependencias.WebApp.Dados;
using _02_03_XX_Inversao_Dependencias.WebApp.Dados.EfCore;
using System;

namespace _02_03_XX_Inversao_Dependencias.WebApp.Controllers
{
    [ApiController]
    [Route("/api/leiloes")]
    public class LeilaoApiController : ControllerBase
    {
        AppDbContext _context;
        ILeilaoDao _dao;

        public LeilaoApiController(ILeilaoDao dao)
        {
            _context = new AppDbContext();
            _dao = dao;
        }

        [HttpGet]
        public IActionResult EndpointGetLeiloes()
        {
            var leiloes = _dao.BuscarTodosLeiloes();
            return Ok(leiloes);
        }

        [HttpGet("{id}")]
        public IActionResult EndpointGetLeilaoById(int id)
        {
            var leilao = _dao.BuscarLeilaoPorId(id);
            if (leilao == null) return NotFound();
            return Ok(leilao);
        }

        [HttpPost]
        public IActionResult EndpointPostLeilao(Leilao leilao)
        {
            _dao.IncluirLeilao(leilao);
            return Ok(leilao);
        }

        [HttpPut]
        public IActionResult EndpointPutLeilao(Leilao leilao)
        {
            if (_dao.BuscarLeilaoPorId(leilao.Id) == null) return NotFound();
            _dao.AlterarLeilao(leilao);
            return Ok(leilao);
        }

        [HttpDelete("{id}")]
        public IActionResult EndpointDeleteLeilao(int id)
        {
            var leilao = _dao.BuscarLeilaoPorId(id);
            if (leilao == null) return NotFound();
            if (leilao.Situacao == SituacaoLeilao.Pregao) return StatusCode(405);
            _dao.ExcluirLeilao(leilao);
            return NoContent();
        }

        [HttpPost("{id}/pregao")]
        public IActionResult EndpointIniciaPregao(int id)
        {
            var leilao = _dao.BuscarLeilaoPorId(id);
            if (leilao == null) return NotFound();
            if (leilao.Situacao != SituacaoLeilao.Rascunho) return StatusCode(405);
            leilao.Situacao = SituacaoLeilao.Pregao;
            leilao.Inicio = DateTime.Now;
            _dao.AlterarLeilao(leilao);
            return Ok();
        }

        [HttpDelete("{id}/pregao")]
        public IActionResult EndpointFinalizaPregao(int id)
        {
            var leilao = _dao.BuscarLeilaoPorId(id);
            if (leilao == null) return NotFound();
            if (leilao.Situacao != SituacaoLeilao.Pregao) return StatusCode(405);
            leilao.Situacao = SituacaoLeilao.Finalizado;
            leilao.Termino = DateTime.Now;
            _dao.AlterarLeilao(leilao);
            return Ok();
        }
    }
}
