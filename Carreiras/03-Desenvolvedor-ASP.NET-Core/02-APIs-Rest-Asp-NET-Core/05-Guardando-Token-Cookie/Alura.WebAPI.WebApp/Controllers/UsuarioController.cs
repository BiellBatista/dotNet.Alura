using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Alura.ListaLeitura.Seguranca;
using Alura.ListaLeitura.WebApp.Models;
using Alura.WebAPI.WebApp.HttpClients;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Alura.ListaLeitura.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        //private readonly UserManager<Usuario> _userManager;
        //private readonly SignInManager<Usuario> _signInManager;
        private readonly AuthApiClient _auth;

        public UsuarioController(
            //já que não usou o identity como 
            //UserManager<Usuario> userManager, 
            //SignInManager<Usuario> signInManager,
            AuthApiClient auth)
        {
            //_userManager = userManager;
            //_signInManager = signInManager;
            _auth = auth;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            //await _signInManager.SignOutAsync();
            //já que estou usando a autenticação pelo httpContext (cookie), não preciso do identity e posos usar os dados vindo pelo head do request
            await HttpContext.SignOutAsync();

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _auth.PostLoginAsync(model);
                //var result = await _signInManager.PasswordSignInAsync(model.Login, model.Password, false, false); //esquema de autenticação do identity
                if (result.Succeeded)
                {
                    /**
                     * Não estou mais usando a autenticação via identity, pois trabalharei com token.
                     * O identity, internamente, usa o método SignInAsync para autenticar
                     */

                    //criando a lista de políticas
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Login),
                        new Claim("Token", result.Token)
                    };
                    //este objeto é construido com dois argumentos e é a identidade: primeiro é a lista de políticas associadas a essa identitdade, o segundo é o shema de autenticação
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    //associando a identidiade a um usuário
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    //este método recebe dois argumentos: primeiro é o schema de autenticação e o segundo são as informações que serão gravadas no cookie
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(String.Empty, "Erro na autenticação");
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var user = new Usuario { UserName = model.Login };
                //var result = await _userManager.CreateAsync(user, model.Password);
                //if (result.Succeeded)
                //{

                //    await _signInManager.SignInAsync(user, isPersistent: false);
                //    return RedirectToAction("Index", "Home");
                //}
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            //await _signInManager.SignOutAsync();
            //realizando o logout pelo contexto
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login");
        }

    }
}
