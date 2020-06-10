using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02_XX_Selenium_WebDriver.Core;
using _02_XX_Selenium_WebDriver.Dados;
using _02_XX_Selenium_WebDriver.WebApp.Models;
using _02_XX_Selenium_WebDriver.WebApp.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _02_XX_Selenium_WebDriver.WebApp.Controllers
{
    public class AutenticacaoController : Controller
    {
        private readonly IRepositorio<Usuario> _repo;

        public AutenticacaoController(IRepositorio<Usuario> repositorio)
        {
            _repo = repositorio;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = _repo.Todos.First(u => u.Email == model.Login && u.Senha == model.Password);
                if (usuario != null)
                {
                    usuario = _repo.BuscarPorId(usuario.Id);
                    //autenticar
                    HttpContext.Session.Set<Usuario>("usuarioLogado", usuario);
                    if (usuario.Interessada == null)
                    {
                        return RedirectToAction("Index", "Leiloes");
                    }
                    return RedirectToAction("Index", "Interessadas");
                }
                ModelState.AddModelError("usuarioInvalido", "Usuário não encontrado");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("usuarioLogado");
            return RedirectToAction("Index", new { Controller = "Home" });
        }
    }
}