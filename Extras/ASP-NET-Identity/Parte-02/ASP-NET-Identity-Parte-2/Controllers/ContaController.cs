using ASP_NET_Identity_Parte_2.Models;
using ASP_NET_Identity_Parte_2.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_Identity_Parte_2.Controllers
{
    public class ContaController : Controller
    {
        // backfiled da propriedade
        private UserManager<UserAplication> _userManager;
        public UserManager<UserAplication> UserManager
        {
            get
            {
                if (_userManager == null)
                {
                    var contextOwin = HttpContext.GetOwinContext();
                    // este método GetUserManager() vem do using Microsoft.AspNet.Identity.Owin;
                    _userManager = contextOwin.GetUserManager<UserManager<UserAplication>>();
                }

                return _userManager;
            }
            set
            {
                _userManager = value;
            }
        }

        // pegando as configurações do OWIN
        private SignInManager<UserAplication, string> _signInManager;
        public SignInManager<UserAplication, string> SignInManager
        {
            get
            {
                if (_signInManager == null)
                {
                    var contextOwin = HttpContext.GetOwinContext();
                    // este método GetUserManager() vem do using Microsoft.AspNet.Identity.Owin;
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

        // GET: Conta
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(ContaRegistrarViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                // isso tudo, entre o //, está no Startup.cs
                ///*
                // * O contexto (DbContext (EntityFramework)) para gerenciar o banco de dados. Passo o a classe do banco de dados, para ele manipular
                // * Passando a connectionstring
                // */
                //var dbContext = new IdentityDbContext<UserAplication>("DefaultConnection");
                ///*
                // * O UserStore(); gera a interface entre o identity e o entityframework. Neste caso, estou criando a interface para os modelos do Usuário
                // * 
                // */
                //var userStore = new UserStore<UserAplication>(dbContext);
                ///*
                // * Uso o userManager para desacoplar o identity do entityframework e gerenciar as persistencia do usuário
                // */
                //var userManager = new UserManager<UserAplication>(userStore);
                ///*
                // * Criando um objeto para armazenar os dados do usuario
                // */
                var novoUsuario = new UserAplication();

                novoUsuario.Email = modelo.Email;
                novoUsuario.UserName = modelo.UserName;
                novoUsuario.FullName = modelo.NomeCompleto;

                // verifcando se o e-mail há está cadastrado na base de dados
                var usuario = await UserManager.FindByEmailAsync(modelo.Email);
                var usuarioJaExiste = usuario != null;

                // se ele existe, volte para o início
                if (usuarioJaExiste)
                    return View("AguardandoConfirmacao");
                //return RedirectToAction("Index", "Home");

                var resultado = await UserManager.CreateAsync(novoUsuario, modelo.Senha);
                // a senha vai como argumento pois ela fica armazenada em outro lugar. Por padrão, o UserManager salva alterações automáticamente
                //await userManager.CreateAsync(novoUsuario, modelo.Senha);
                // não preciso mais do dbContext, pois irei usar algo menos desacoplado
                //dbContext.Users.Add(novoUsuario);
                //dbContext.SaveChanges();
                // verificando se houve erro na hora de salvar o dado
                if (resultado.Succeeded)
                {
                    await EnviarEmailDeConfirmacaoAsync(novoUsuario);
                    return View("AguardandoConfirmacao");
                    //return RedirectToAction("Index", "Home");
                }
                else
                {
                    AdicionaErros(resultado);
                }
            }

            return View(modelo);
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
                        // isPersistent serve para verificar se o usuário deseja continuar logado
                        // true continua logado. False não continua logado
                        isPersistent: modelo.ContinuarLogado,
                        // shouldLockout ativa o limite máximo de login de falhas
                        shouldLockout: true);

                switch (signInResultado)
                {
                    case SignInStatus.Success:
                        if (!usuario.EmailConfirmed) // verificando se o usuário confirmou o e-mail
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

        public ActionResult EsqueciSenha()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> EsqueciSenha(ContaEsqueciSenhaViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                // Gerar o token de reset da senha
                // Gerar a url para o usuário
                // Vamos enviar o e-mail
                // recuperando o usuário
                var usuario = await UserManager.FindByEmailAsync(modelo.Email);

                if (usuario != null)
                {
                    // gerando o token para o usuário resetar sua senha
                    var token = await UserManager.GeneratePasswordResetTokenAsync(usuario.Id);

                    var linkDeCallBack =
                        Url.Action(
                            "ConfirmacaoAlteracaoSenha",
                            "Conta",
                            new { usuarioId = usuario.Id, token = token },
                            Request.Url.Scheme);

                    // montando o e-mail
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
            if(ModelState.IsValid)
            {
                //verifica o token recebido
                //verifica o id do usuário
                //mudar a senha

                var resultadoAlteracao = await UserManager.ResetPasswordAsync(
                    modelo.UsuarioId,
                    modelo.Token,
                    modelo.NovaSenha
                    );

                if(resultadoAlteracao.Succeeded)
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
            // matando o cookie do usuário e encerrando a sessão dele
            AutenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Index", "Home");
        }

        private async Task EnviarEmailDeConfirmacaoAsync(UserAplication usuario)
        {
            //token de confirmacao de email
            var token = await UserManager.GenerateEmailConfirmationTokenAsync(usuario.Id);

            var linkDeCallBack =
                Url.Action(
                    "ConfirmacaoEmail",
                    "Conta",
                    new { usuarioId = usuario.Id, token = token },
                    Request.Url.Scheme);

            // montando o e-mail
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
                // adicionando erro no modelstate para o usuário ver o que está errado
                ModelState.AddModelError("", erro);
        }
    }
}

/*
 * Arquitetura do Identity
 * Fontes de Dados (SQL, MongoDB)
 * Acesso aos Dados (EntityFramework, NHibernate)
 * Fonecedor/Store (UserStore)
 * Gerenciador/Managers (UserManager)
 * Aplicação
 * 
 * 
 * A aplicação conversa apenas com o gerenciador para a manipulação dos dados do usuário
 */
