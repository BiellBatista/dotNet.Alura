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
            //services.AddTransient<ICatalogo, Catalogo>(); //criando um cerviço temporário (transidório), ou seja, toda fez que for solicitado um serviceProvider.GetService<>(), será instanciado um novo objeto. Passo dois parametros, a interface e o objeto concreto
            //services.AddTransient<IRelatorio, Relatorio>();

            //services.AddScoped<ICatalogo, Catalogo>(); //criando um serviço de escopo, ou seja, toda fez que for realizado um request, o objeto será instanciado apenas uma vez. Passo dois parametros, a interface e o objeto concreto
            //services.AddScoped<IRelatorio, Relatorio>();

            var catalogo = new Catalogo();
            services.AddSingleton<ICatalogo>(catalogo); //criando um serviço único, ou seja, enquanto a aplicação estiver rodando, existirá apenas uma instancia de catalogo. Passo dois parametros, a interface e o objeto concreto
            services.AddSingleton<IRelatorio>(new Relatorio(catalogo));
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
            IRelatorio relatorio = serviceProvider.GetService<IRelatorio>(); // solicitando o relatorio como serviço. ASsim, não mexo na classe concreta

            app.Run(async (context) =>
            {
                await relatorio.Imprimir(context);
            });
        }
    }
}
