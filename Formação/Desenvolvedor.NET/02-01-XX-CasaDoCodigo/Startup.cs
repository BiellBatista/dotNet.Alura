using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace _02_01_XX_CasaDoCodigo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Este método serve para configurar (definir fluxo de chamadas da aplicação) os serviços adicionados no método "ConfigureServices"
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var livros = new List<Livro>();
            livros.Add(new Livro("001", "Quem mexeu na minha query?", 12.99m));
            livros.Add(new Livro("002", "Fique com o C#", 30.99m));
            livros.Add(new Livro("003", "Java para Baixinhos", 25.99m));

            app.Run(async (context) =>
            {
                foreach(var livro in livros)
                    //o \r é o return. Ou seja, retorne uma nova linha
                    await context.Response.WriteAsync($"{livro.Codigo, -10}{livro.Nome, -40}{livro.Preco.ToString("C"), 10}\r\n");
            });
        }
    }
}
