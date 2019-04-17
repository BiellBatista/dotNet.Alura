using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        // Os parametros IXXXX serve para passar a responsabilidade de criação para o ASP.NET Core. Injeção de depedência
        public void ConfigureServices(IServiceCollection services)
        {
            // falando que a aplicação usa o serviço de roteamento nativo do ASP.NET Core
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app); //criando o objeto complexo de rotas
            //configurando as rotas
            builder.MapRoute("Livros/ParaLer", LivrosParaLer); //para cada rota que quero atender, chamo o método MapRoute()
            builder.MapRoute("Livros/Lendo", LivrosLendo); //para cada rota que quero atender, chamo o método MapRoute()
            builder.MapRoute("Livros/Lidos", LivrosLidos); //para cada rota que quero atender, chamo o método MapRoute()
            builder.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", NovoLivroParaLer); //criando uma rota com template.
            builder.MapRoute("Livros/Detalhes/{id:int}", ExibeDetalhes); //criando uma rota com template que aceite apenas int como parametro. Assim, o servido não atenden esta chamada e evita erros 500, pois não haverá erro na hora de converter uma string para um inteiro
            // Rota com template segue o padrão Cadastro/NovoLivro/{nome}/{autor}, onde os valores entre {} são argumentos

            var rotas = builder.Build(); //construindo as rotas. O método Build() é usado para construir objetos complexos
            app.UseRouter(rotas); //usando a rota nativa do Core e deixando a minha rota de lado

            /*
             * A sequência de requisição e resposta é chamada de, no .CORE, RequestPipeline
             * A interface IApplicationBuilder é responsável por fazer o pipeline
             */
            //app.Run(LivrosParaLer); //execute o método LivrosParaLer. Um RequestDelegate é um método que tem como retorno um Task
            //app.Run(Roteamento); //minha rota
        }

        private Task ExibeDetalhes(HttpContext context)
        {
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(l => l.Id == id);

            return context.Response.WriteAsync(livro.Detalhes());
        }

        public Task NovoLivroParaLer(HttpContext context)
        {
            var livro = new Livro()
            {
                Titulo = context.GetRouteValue("nome").ToString(), //pegando o primeiro valor da rota
                Autor = context.GetRouteValue("autor").ToString() //pegando o segundo valor da rota
            };
            var repo = new LivroRepositorioCSV();

            repo.Incluir(livro);

            return context.Response.WriteAsync("O livro foi adicionado com sucesso");
        }

        // qualquer requisição realizada no browser, irá passar pelo roteador
        // o context serve para ver tudo que posso fazer no contexto do HTTP
        public Task Roteamento(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            //var caminhosAtendidos = new Dictionary<string, string>
            //{
            //    {"/Livros/ParaLer", _repo.ParaLer.ToString() },
            //    {"/Livros/Lendo", _repo.Lendo.ToString() },
            //    {"/Livros/Lidos", _repo.Lidos.ToString() }
            //};

            var caminhosAtendidos = new Dictionary<string, RequestDelegate>
            {
                {"/Livros/ParaLer", LivrosParaLer },
                {"/Livros/Lendo", LivrosLendo },
                {"/Livros/Lidos", LivrosLidos }
            };

            if (caminhosAtendidos.ContainsKey(context.Request.Path))
            {
                var metodo = caminhosAtendidos[context.Request.Path];
                return metodo.Invoke(context); //invocando um método delegate e passando o contexto (ambiente do usuário) para ele saber onde irá a resposta
                //return context.Response.WriteAsync(caminhosAtendidos[context.Request.Path]);
            }
            context.Response.StatusCode = 404; // adicionado um código de erro (404) para página não encontrada. Posso colocar qualquer coisa
            return context.Response.WriteAsync("Caminho não encontrado");
        }

        public Task LivrosLendo(HttpContext context)
        {
            // esrevendo a lista de livros
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lendo.ToString());
        }

        public Task LivrosLidos(HttpContext context)
        {
            // esrevendo a lista de livros
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lidos.ToString());
        }

        // Toda informação do HTTP é encapsulada na calsse HttpContext
        public Task LivrosParaLer(HttpContext context)
        {
            // esrevendo a lista de livros
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.ParaLer.ToString());
        }
        /*
         * o compilador ignora os modificadores (public, private, protected...) na avaliação de um delegate.
         * 
         * Escolha a alternativa com a melhor definição para Request Pipeline.
         * 
         * Termo usado pelo ASP.NET Core para representar o fluxo que uma requisição HTTP percorre dentro de sua aplicação até que a resposta seja entregue ao cliente.
         * O código que escrevemos nesse pipeline é chamado Middleware.
         */
    }
}