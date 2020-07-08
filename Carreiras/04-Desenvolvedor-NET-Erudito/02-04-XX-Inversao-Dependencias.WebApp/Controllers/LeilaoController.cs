using System.Linq;
using Microsoft.AspNetCore.Mvc;
using _02_04_XX_Inversao_Dependencias.WebApp.Dados;
using _02_04_XX_Inversao_Dependencias.WebApp.Dados.EfCore;
using _02_04_XX_Inversao_Dependencias.WebApp.Models;
using System;

namespace _02_04_XX_Inversao_Dependencias.WebApp.Controllers
{
    public class LeilaoController : Controller
    {
        AppDbContext _context;
        ILeilaoDao _dao;

        public LeilaoController(ILeilaoDao dao)
        {
            _context = new AppDbContext();
            _dao = dao;
        }

        public IActionResult Index()
        {
            var leiloes = _dao.BuscarTodosLeiloes();
            return View(leiloes);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            ViewData["Categorias"] = _dao.BuscarTodasCategorias();
            ViewData["Operacao"] = "Inclusão";
            return View("Form");
        }

        [HttpPost]
        public IActionResult Insert(Leilao model)
        {
            if (ModelState.IsValid)
            {
                _dao.IncluirLeilao(model);
                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = _dao.BuscarTodasCategorias();
            ViewData["Operacao"] = "Inclusão";
            return View("Form", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Categorias"] = _dao.BuscarTodasCategorias();
            ViewData["Operacao"] = "Edição";
            var leilao = _dao.BuscarLeilaoPorId(id);
            if (leilao == null) return NotFound();
            return View("Form", leilao);
        }

        [HttpPost]
        public IActionResult Edit(Leilao model)
        {
            if (ModelState.IsValid)
            {
                _dao.AlterarLeilao(model);
                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = _dao.BuscarTodasCategorias();
            ViewData["Operacao"] = "Edição";
            return View("Form", model);
        }

        [HttpPost]
        public IActionResult Inicia(int id)
        {
            var leilao = _dao.BuscarLeilaoPorId(id);
            if (leilao == null) return NotFound();
            if (leilao.Situacao != SituacaoLeilao.Rascunho) return StatusCode(405);
            leilao.Situacao = SituacaoLeilao.Pregao;
            leilao.Inicio = DateTime.Now;
            _dao.AlterarLeilao(leilao);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Finaliza(int id)
        {
            var leilao = _dao.BuscarLeilaoPorId(id);
            if (leilao == null) return NotFound();
            if (leilao.Situacao != SituacaoLeilao.Pregao) return StatusCode(405);
            leilao.Situacao = SituacaoLeilao.Finalizado;
            leilao.Termino = DateTime.Now;
            _dao.AlterarLeilao(leilao);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var leilao = _dao.BuscarLeilaoPorId(id);
            if (leilao == null) return NotFound();
            if (leilao.Situacao == SituacaoLeilao.Pregao) return StatusCode(405);
            _dao.ExcluirLeilao(leilao);
            return NoContent();
        }

        [HttpGet]
        public IActionResult Pesquisa(string termo)
        {
            ViewData["termo"] = termo;
            var leiloes = _dao.BuscarTodosLeiloes()
                .Where(l => string.IsNullOrWhiteSpace(termo) ||
                    l.Titulo.ToUpper().Contains(termo.ToUpper()) ||
                    l.Descricao.ToUpper().Contains(termo.ToUpper()) ||
                    l.Categoria.Descricao.ToUpper().Contains(termo.ToUpper())
                );
            return View("Index", leiloes);
        }
    }
}
