﻿using ASP_NET_Identity_Parte_3.Models;
using ASP_NET_Identity_Parte_3.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_Identity_Parte_3.Controllers
{
    public class ContaController : Controller
    {
        private UserManager<UserAplication> _userManager;
        private SignInManager<UserAplication, string> _signInManager;

        public UserManager<UserAplication> UserManager
        {
            get
            {
                if (_userManager == null)
                {
                    var contextOwin = HttpContext.GetOwinContext();
                    _userManager = contextOwin.GetUserManager<UserManager<UserAplication>>();
                }

                return _userManager;
            }
            set
            {
                _userManager = value;
            }
        }


        public SignInManager<UserAplication, string> SignInManager
        {
            get
            {
                if (_signInManager == null)
                {
                    var contextOwin = HttpContext.GetOwinContext();
                    _signInManager = contextOwin.GetUserManager<SignInManager<UserAplication, string>>();
                }

                return _signInManager;
            }
            set
            {
                _signInManager = value;
            }
        }

        public IAuthenticationManager AutenticationManager
        {
            get
            {
                var contextoOwin = Request.GetOwinContext();
                return contextoOwin.Authentication;
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(ContaRegistrarViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var novoUsuario = new UserAplication();

                novoUsuario.Email = modelo.Email;
                novoUsuario.UserName = modelo.UserName;
                novoUsuario.FullName = modelo.NomeCompleto;

                var usuario = await UserManager.FindByEmailAsync(modelo.Email);
                var usuarioJaExiste = usuario != null;

                if (usuarioJaExiste)
                    return View("AguardandoConfirmacao");

                var resultado = await UserManager.CreateAsync(novoUsuario, modelo.Senha);
                if (resultado.Succeeded)
                {
                    await EnviarEmailDeConfirmacaoAsync(novoUsuario);
                    return View("AguardandoConfirmacao");
                }
                else
                {
                    AdicionaErros(resultado);
                }
            }

            return View(modelo);
        }

        [HttpPost]
        //o argumento vem do button (que possui o name igual ao do argumento) e o valor está contido no atributo value
        public ActionResult RegistrarPorAutenticacaoExterna(string provider)
        {
            SignInManager.AuthenticationManager.Challenge(new AuthenticationProperties
            {
                RedirectUri = Url.Action("RegistrarPorAutenticacaoExternaCallback")
            }, provider);

            return new HttpUnauthorizedResult();
        }

        public async Task<ActionResult> RegistrarPorAutenticacaoExternaCallback()
        {
            var loginInfo = await SignInManager.AuthenticationManager.GetExternalLoginInfoAsync();
            // verificando se o usuário existe, mesmo se for conexão externa (Google, Twitter...)
            var usuarioExistente = await UserManager.FindByEmailAsync(loginInfo.Email);

            if (usuarioExistente != null)
                return View("Error");

            var novoUsuario = new UserAplication();
            novoUsuario.Email = loginInfo.Email;
            novoUsuario.UserName = loginInfo.Email;
            novoUsuario.FullName =
                loginInfo.ExternalIdentity.FindFirstValue(loginInfo.ExternalIdentity.NameClaimType);

            // criando o usuário sem a senha, porque não é mais necessário. Afinal, estamos usando uma autenticação externa
            var resultado = await UserManager.CreateAsync(novoUsuario);

            if (resultado.Succeeded)
            {
                // é necessário adicionar uma forma de login
                var resultadoAddLoginInfo = await UserManager.AddLoginAsync(novoUsuario.Id, loginInfo.Login);

                if (resultadoAddLoginInfo.Succeeded)
                    return RedirectToAction("Index", "Home");
            }

            return View("Error");
        }

        public async Task<ActionResult> ConfirmacaoEmail(string usuarioId, string token)
        {
            if (usuarioId == null || token == null)
                return View("Error");
            var resultado = await UserManager.ConfirmEmailAsync(usuarioId, token);

            if (resultado.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<ActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(ContaLoginViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var usuario = await UserManager.FindByEmailAsync(modelo.Email);

                if (usuario == null)
                    return SenhaOuUsuarioInvalido();


                var signInResultado =
                    await SignInManager.PasswordSignInAsync(
                        usuario.UserName,
                        modelo.Senha,
                        isPersistent: modelo.ContinuarLogado,
                        shouldLockout: true);

                switch (signInResultado)
                {
                    case SignInStatus.Success:
                        if (!usuario.EmailConfirmed)
                        {
                            AutenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                            return View("AguardandoConfirmacao");
                        }
                        return RedirectToAction("Index", "Home");
                    case SignInStatus.LockedOut:
                        var senhaCorreta = await UserManager.CheckPasswordAsync(usuario, modelo.Senha);

                        if (senhaCorreta)
                            ModelState.AddModelError("", "A conta está bloqueada");
                        else
                            return SenhaOuUsuarioInvalido();
                        break;
                    default:
                        SenhaOuUsuarioInvalido();
                        break;
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult LoginPorAutenticacaoExterna(string provider)
        {
            SignInManager.AuthenticationManager.Challenge(new AuthenticationProperties
            {
                RedirectUri = Url.Action("LoginPorAutenticacaoExternaCallback")
            }, provider);

            return new HttpUnauthorizedResult();
        }

        public async Task<ActionResult> LoginPorAutenticacaoExternaCallback()
        {
            // pegando o login, retornado pelo provider, do usuário
            var loginInfo = await SignInManager.AuthenticationManager.GetExternalLoginInfoAsync();
            var signInResultado = await SignInManager.ExternalSignInAsync(loginInfo, true);

            if (signInResultado == SignInStatus.Success)
                return RedirectToAction("Index", "Home");

            return View("Error");
        }

        public ActionResult EsqueciSenha()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> EsqueciSenha(ContaEsqueciSenhaViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var usuario = await UserManager.FindByEmailAsync(modelo.Email);

                if (usuario != null)
                {
                    var token = await UserManager.GeneratePasswordResetTokenAsync(usuario.Id);

                    var linkDeCallBack =
                        Url.Action(
                            "ConfirmacaoAlteracaoSenha",
                            "Conta",
                            new { usuarioId = usuario.Id, token = token },
                            Request.Url.Scheme);

                    await UserManager.SendEmailAsync(
                        usuario.Id,
                        "Teste - Alteração de Senha",
                        $"Bem vindo ao teste, clique aqui {linkDeCallBack} para alterar a sua senha!"
                        );
                }

                return View("EmailAlteracaoSenhaEnviado");
            }
            return View();
        }

        public ActionResult ConfirmacaoAlteracaoSenha(string usuarioId, string token)
        {
            var modelo = new ContaConfirmacaoAlteracaoSenhaViewModel
            {
                UsuarioId = usuarioId,
                Token = token
            };

            return View(modelo);
        }

        [HttpPost]
        public async Task<ActionResult> ConfirmacaoAlteracaoSenha(ContaConfirmacaoAlteracaoSenhaViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var resultadoAlteracao = await UserManager.ResetPasswordAsync(
                    modelo.UsuarioId,
                    modelo.Token,
                    modelo.NovaSenha
                    );

                if (resultadoAlteracao.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                AdicionaErros(resultadoAlteracao);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Logoff()
        {
            AutenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Index", "Home");
        }

        private async Task EnviarEmailDeConfirmacaoAsync(UserAplication usuario)
        {
            var token = await UserManager.GenerateEmailConfirmationTokenAsync(usuario.Id);

            var linkDeCallBack =
                Url.Action(
                    "ConfirmacaoEmail",
                    "Conta",
                    new { usuarioId = usuario.Id, token = token },
                    Request.Url.Scheme);

            await UserManager.SendEmailAsync(
                usuario.Id,
                "Teste - Confirmação de E-mail",
                $"Bem vindo ao teste, clique aqui {linkDeCallBack} para confirmar seu endereço de e-mail!"
                );
        }

        private ActionResult SenhaOuUsuarioInvalido()
        {
            ModelState.AddModelError("", "Credencias inválidas!");
            return View("Login");
        }

        private void AdicionaErros(IdentityResult resultado)
        {
            foreach (var erro in resultado.Errors)
                ModelState.AddModelError("", erro);
        }
    }
}