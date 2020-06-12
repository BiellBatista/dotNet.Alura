
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _04_XX_Selenium_WebDriver.WebApp.Filtros;
using _04_XX_Selenium_WebDriver.WebApp.Models;
using _04_XX_Selenium_WebDriver.Core;
using _04_XX_Selenium_WebDriver.Dados;
using _04_XX_Selenium_WebDriver.WebApp.Extensions;

namespace _04_XX_Selenium_WebDriver.WebApp.Controllers
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

        private IEnumerable<Leilao> PesquisaLeiloes(PesquisaLeiloesViewModel pesquisa)
        {
            if (pesquisa.Andamento == null && pesquisa.Categorias == null && pesquisa.Termo == null)
                return null;
            var leiloes = _repoLeilao.Todos;
            if (!string.IsNullOrEmpty(pesquisa.Andamento))
            {
                leiloes = leiloes.Where(l => l.Estado == EstadoLeilao.LeilaoEmAndamento);
            }
            if (!string.IsNullOrWhiteSpace(pesquisa.Termo))
            {
                leiloes = leiloes.Where(l => l.Titulo.Contains(pesquisa.Termo, StringComparison.InvariantCultureIgnoreCase));
            }
            if (pesquisa.Categorias != null && pesquisa.Categorias.Length > 0)
            {
                leiloes = leiloes.Where(l => pesquisa.Categorias.Contains(l.Categoria));
            }
            return leiloes.ToList();
        }

        public IActionResult Index(PesquisaLeiloesViewModel pesquisa)
        {
            var usuarioLogado = this.HttpContext.Session.Get<Usuario>("usuarioLogado");
            var interessada = _repoInteressada
                .BuscarPorId(usuarioLogado.Interessada.Id);
            var model = new DashboardInteressadaViewModel
            {
                MinhasOfertas = interessada.Lances,
                LeiloesFavoritos = interessada.Favoritos.Select(f => f.LeilaoFavorito),
                LeiloesPesquisados = PesquisaLeiloes(pesquisa)
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