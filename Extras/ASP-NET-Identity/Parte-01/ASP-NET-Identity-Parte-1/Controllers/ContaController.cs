using ASP_NET_Identity_Parte_1.Models;
using ASP_NET_Identity_Parte_1.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_Identity_Parte_1.Controllers
{
    public class ContaController : Controller
    {
        // GET: Conta
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ContaRegistrarViewModel modelo)
        {
            if(ModelState.IsValid)
            {
                /*
                 * O contexto (DbContext (EntityFramework)) para gerenciar o banco de dados. Passo o a classe do banco de dados, para ele manipular
                 */
                var dbContext = new IdentityDbContext<UserAplication>();
                /*
                 * Criando um objeto para armazenar os dados do usuario
                 */
                var novoUsuario = new UserAplication();

                novoUsuario.Email = modelo.Email;
                novoUsuario.UserName = modelo.UserName;
                novoUsuario.FullName = modelo.NomeCompleto;

                dbContext.Users.Add(novoUsuario);
                dbContext.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(modelo);
        }
    }
}