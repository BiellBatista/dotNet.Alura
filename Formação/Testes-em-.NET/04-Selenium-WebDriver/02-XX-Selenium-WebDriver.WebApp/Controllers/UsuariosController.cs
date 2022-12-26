﻿using Microsoft.AspNetCore.Mvc;
using _02_XX_Selenium_WebDriver.WebApp.Models;
using _02_XX_Selenium_WebDriver.Dados;
using _02_XX_Selenium_WebDriver.Core;

namespace _02_XX_Selenium_WebDriver.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IRepositorio<Usuario> _repo;

        public UsuariosController(IRepositorio<Usuario> repositorio)
        {
            _repo = repositorio;
        }

        [HttpPost]
        public IActionResult Registro(RegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                //registrar usuário/interessado
                var usuario = new Usuario { Email = model.Email, Senha = model.Password, Interessada = new Interessada(model.Nome) };
                _repo.Incluir(usuario);
                return RedirectToAction("Agradecimento");
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Agradecimento()
        {
            return View();
        }
    }
}