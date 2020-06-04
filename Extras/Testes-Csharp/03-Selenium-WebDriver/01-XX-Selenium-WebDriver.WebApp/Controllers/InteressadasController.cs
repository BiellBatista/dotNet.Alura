using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _01_XX_Selenium_WebDriver.WebApp.Filtros;
using _01_XX_Selenium_WebDriver.WebApp.Models;
using _01_XX_Selenium_WebDriver.Core;
using _01_XX_Selenium_WebDriver.Dados;
using _01_XX_Selenium_WebDriver.WebApp.Extensions;

namespace _01_XX_Selenium_WebDriver.WebApp.Controllers
{
    [AutorizacaoFilter]
    public class InteressadasController : Controller
    {

        private readonly IRepositorio<Leilao> _repoLeilao;
        private readonly IRepositorio<Interessada> _repoInteressada;

        public InteressadasController(
            IRepositorio<Leilao> repoLeilao, 
            IRepositorio<Interessada> repoInteressada)
        {
            _repoLeilao = repoLeilao;
            _repoInteressada = repoInteressada;
        }

        public IActionResult Index()
        {
            var usuarioLogado = this.HttpContext.Session.Get<Usuario>("usuarioLogado");
            var interessada = _repoInteressada
                .BuscarPorId(usuarioLogado.Interessada.Id);
            var model = new DashboardInteressadaViewModel
            {
                MinhasOfertas = interessada.Lances,
                LeiloesFavoritos = interessada.Favoritos.Select(f => f.LeilaoFavorito)
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult OfertaLance(LanceViewModel model)
        {
            if (ModelState.IsValid)
            {
                Leilao leilao = _repoLeilao.BuscarPorId(model.LeilaoId);
                Interessada interessada = _repoInteressada.BuscarPorId(model.UsuarioLogadoId);
                leilao.RecebeLance(interessada, model.Valor);
                _repoLeilao.Alterar(leilao); //?
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult SeguirLeilao(FavoritoViewModel model)
        {
            var leilao = _repoLeilao.BuscarPorId(model.IdLeilao);
            if (leilao != null)
            {
                var favorito = new Favorito
                {
                    IdLeilao = model.IdLeilao,
                    IdInteressada = model.IdInteressada
                };
                leilao.Seguidores.Add(favorito);
                _repoLeilao.Alterar(leilao);
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AbandonarLeilao(FavoritoViewModel model)
        {
            var leilao = _repoLeilao.BuscarPorId(model.IdLeilao);
            if (leilao != null)
            {
                var favorito = leilao.Seguidores
                    .FirstOrDefault(s =>
                        s.IdLeilao == model.IdLeilao &&
                        s.IdInteressada == model.IdInteressada);
                leilao.Seguidores.Remove(favorito);
                _repoLeilao.Alterar(leilao);
                return Ok();
            }
            return NotFound();
        }

    }
}