using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace _02_01_XX_CasaDoCodigo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICatalogo, Catalogo>(); //criando um cerviço temporário (transidório). Passo dois parametros, a interface e o objeto concreto
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Este método serve para configurar (definir fluxo de chamadas da aplicação) os serviços adicionados no método "ConfigureServices"
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            /*
             * Fazendo com que a classe Startup não manipule as classes concretas de Catalago e Relatorio. Para isso, extrair interfaces de cada uma
             * e modifiquei os tipos aqui na classe. Lembrando que isso é injeção de depedência.
             * Além disos tudo, é necessário soliciar o Catalago como serviço
             */
            ICatalogo catalogo = serviceProvider.GetService<ICatalogo>(); // solicitando o catalago como serviço. ASsim, não mexo na classe concreta
            IRelatorio relatorio = new Relatorio(catalogo);

            app.Run(async (context) =>
            {
                await relatorio.Imprimir(context);
            });
        }
    }
}
