using ASP_NET_Identity_Parte_4.App_Start.Identity;
using ASP_NET_Identity_Parte_4.Models;
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

[assembly: OwinStartup(typeof(ASP_NET_Identity_Parte_4.Sartup))]

namespace ASP_NET_Identity_Parte_4
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

            builder.CreatePerOwinContext<RoleStore<IdentityRole>>(
                (opcoes, contextOwin) =>
                {
                    var dbContext = contextOwin.Get<DbContext>();
                    return new RoleStore<IdentityRole>(dbContext);
                });

            builder.CreatePerOwinContext<RoleManager<IdentityRole>>(
                (opcoes, contextOwin) =>
                {
                    var roleStore = contextOwin.Get<RoleStore<IdentityRole>>();
                    return new RoleManager<IdentityRole>(roleStore);
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
                    // configurando o serviço de SMS
                    userManager.SmsService = new SMSServico();

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

            builder.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });

            builder.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            builder.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions
            {
                ClientId = ConfigurationManager.AppSettings["google:client_id"],
                ClientSecret = ConfigurationManager.AppSettings["google:client_secret"],
                Caption = "Google"
            });

            using (var dbContext = new IdentityDbContext<UserAplication>("DefaultConnection"))
            {
                CriarRoles(dbContext);
                CriarAdministrador(dbContext);
            }
        }

        private void CriarRoles(IdentityDbContext<UserAplication> dbContext)
        {
            using (var roleStore = new RoleStore<IdentityRole>(dbContext))
            using (var roleManager = new RoleManager<IdentityRole>(roleStore))
            {
                if (!roleManager.RoleExists(RolesName.ADMINISTRADOR))
                    roleManager.Create(new IdentityRole(RolesName.ADMINISTRADOR));

                if (!roleManager.RoleExists(RolesName.MODERADOR))
                    roleManager.Create(new IdentityRole(RolesName.MODERADOR));
            }

        }

        private void CriarAdministrador(IdentityDbContext<UserAplication> dbContext)
        {
            using (var userSotre = new UserStore<UserAplication>(dbContext))
            using (var userManager = new UserManager<UserAplication>(userSotre))
            {
                var admEmail = ConfigurationManager.AppSettings["admin:email"];
                var administrador = userManager.FindByEmail(admEmail);

                if (administrador != null)
                    return;

                administrador = new UserAplication();

                administrador.Email = admEmail;
                administrador.EmailConfirmed = true;
                administrador.UserName = ConfigurationManager.AppSettings["admin:user_name"];
                userManager.Create(administrador, ConfigurationManager.AppSettings["admin:senha"]);

                userManager.AddToRole(administrador.Id, RolesName.ADMINISTRADOR);
            }
        }
    }
}
