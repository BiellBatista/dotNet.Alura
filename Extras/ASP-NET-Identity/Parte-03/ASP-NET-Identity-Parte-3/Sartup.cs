using ASP_NET_Identity_Parte_3.App_Start.Identity;
using ASP_NET_Identity_Parte_3.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using System;
using System.Configuration;
using System.Data.Entity;

[assembly: OwinStartup(typeof(ASP_NET_Identity_Parte_3.Sartup))]

namespace ASP_NET_Identity_Parte_3
{
    public class Sartup
    {
        public void Configuration(IAppBuilder builder)
        {
            builder.CreatePerOwinContext<DbContext>(() =>
                new IdentityDbContext<UserAplication>("DefaultConnection")
                );

            builder.CreatePerOwinContext<IUserStore<UserAplication>>(
                (opcoes, contextOwin) =>
                {
                    var dbContext = contextOwin.Get<DbContext>();
                    return new UserStore<UserAplication>(dbContext);
                });

            builder.CreatePerOwinContext<UserManager<UserAplication>>(
                (opcoes, contextOwin) =>
                {
                    var userStore = contextOwin.Get<IUserStore<UserAplication>>();
                    var userManager = new UserManager<UserAplication>(userStore);

                    var userValidator = new UserValidator<UserAplication>(userManager);
                    userValidator.RequireUniqueEmail = true;

                    userManager.UserValidator = userValidator;
                    userManager.PasswordValidator = new SenhaValidador()
                    {
                        TamanhoRequerido = 6,
                        ObrigatorioCaracteresEspeciais = true,
                        ObrigatorioDigitos = true,
                        ObrigatorioLowerCase = true,
                        ObrigatorioUpperCase = true
                    };

                    userManager.EmailService = new EmailServico();

                    var dataProtectionProvider = opcoes.DataProtectionProvider;
                    var dataProtectionProvidresCreated = dataProtectionProvider.Create("ByteBank.Forum");
                    userManager.UserTokenProvider = new DataProtectorTokenProvider<UserAplication>(dataProtectionProvidresCreated);

                    userManager.MaxFailedAccessAttemptsBeforeLockout = 3;
                    userManager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    userManager.UserLockoutEnabledByDefault = true;

                    return userManager;
                });

            builder.CreatePerOwinContext<SignInManager<UserAplication, string>>(
                (opcoes, contextOwin) =>
                {
                    var userManager = contextOwin.Get<UserManager<UserAplication>>();
                    var signInManager = new SignInManager<UserAplication, string>(
                        userManager,
                        contextOwin.Authentication);

                    return signInManager;
                });

            // cookie gerado pela aplicação
            builder.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });

            // cookie gerado por servidor externo (aplicativo de terceiros), para autenticar o usuário
            builder.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // configurando a autenticação do Google
            builder.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions
            {
                ClientId = ConfigurationManager.AppSettings["google:client_id"], //id gerado pela API na página do google (arquivo client_id.json)
                ClientSecret = ConfigurationManager.AppSettings["google:client_secret"], //secret gerado pela API na página do google (arquivo client_id.json)
                Caption = "Google"
            });
        }
    }
}
/*
 * Erros sobre middwelare envolve o Owin
 */