using ASP_NET_Identity_Parte_2.App_Start.Identity;
using ASP_NET_Identity_Parte_2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

// este assembly defini para o Owin a classe/tipo de inicialização
[assembly: OwinStartup(typeof(ASP_NET_Identity_Parte_2.Sartup))]

namespace ASP_NET_Identity_Parte_2
{
    /*
     * Classe para configurar o Owin. O Owin é responsável por gerenciar o pipelina entre a aplicação e o servidor
     */
    public class Sartup
    {
        /* sou obrigado a colocar o método Coniguration
         * ele recebe como argumento o pipeline da aplicação
         */
        public void Configuration(IAppBuilder builder)
        {
            // a cada contexto do Owin, crie o tipo DbContext. Falando para o Owin qual o dbcontext
            builder.CreatePerOwinContext<DbContext>(() =>
                new IdentityDbContext<UserAplication>("DefaultConnection")
                );
            // a cada contexto do Owin, crie um UserStore
            builder.CreatePerOwinContext<IUserStore<UserAplication>>(
                (opcoes, contextOwin) =>
                {
                    // método Get vem do pacote using Microsoft.AspNet.Identity.Owin;
                    var dbContext = contextOwin.Get<DbContext>();
                    return new UserStore<UserAplication>(dbContext);
                });
            // a cada contexto do Owin, crie o UserManager
            builder.CreatePerOwinContext<UserManager<UserAplication>>(
                (opcoes, contextOwin) =>
                {
                    var userStore = contextOwin.Get<IUserStore<UserAplication>>();
                    //é no Owin que o UserManager é construido
                    var userManager = new UserManager<UserAplication>(userStore);

                    var userValidator = new UserValidator<UserAplication>(userManager);
                    userValidator.RequireUniqueEmail = true; // tornando os e-mail único

                    userManager.UserValidator = userValidator; //passando o novo objeto de validação para o gerenciador de usuario
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

                    return userManager;
                });

            // a cada contexto do Owin, crie o SignInManager (responsável por gerenciar a senha)
            builder.CreatePerOwinContext<SignInManager<UserAplication, string>>(
                (opcoes, contextOwin) =>
                {
                    // pegando os dados do usuário
                    var userManager = contextOwin.Get<UserManager<UserAplication>>();

                    var signInManager = new SignInManager<UserAplication, string>(
                        userManager,
                        //auteciador.Isso vem porque estou usando o Owin, Identity e o plugin do Identity no Owin
                        contextOwin.Authentication);

                    return signInManager;
                });
        }
    }
}
/*
 * Um contexto do Owin ocorre a cada requisição (GET, POST, PUT, DELETE)
 */
