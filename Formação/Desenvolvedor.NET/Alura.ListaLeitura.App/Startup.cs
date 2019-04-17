using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            /*
             * A sequência de requisição e resposta é chamada de, no .CORE, RequestPipeline
             * A interface IApplicationBuilder é responsável por fazer o pipeline
             */
            //app.Run(LivrosParaLer); //execute o método LivrosParaLer. Um RequestDelegate é um método que tem como retorno um Task
            app.Run(Roteamento);
        }

        // qualquer requisição realizada no browser, irá passar pelo roteador
        // o context serve para ver tudo que posso fazer no contexto do HTTP
        public Task Roteamento(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var caminhosAtendidos = new Dictionary<string, string>
            {
                {"/Livros/ParaLer", _repo.ParaLer.ToString() },
                {"/Livros/Lendo", _repo.Lendo.ToString() },
                {"/Livros/Lidos", _repo.Lidos.ToString() }
            };

            if(caminhosAtendidos.ContainsKey(context.Request.Path))
                return context.Response.WriteAsync(caminhosAtendidos[context.Request.Path]);
            context.Response.StatusCode = 404; // adicionado um código de erro (404) para página não encontrada. Posso colocar qualquer coisa
            return context.Response.WriteAsync("Caminho não encontrado");
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