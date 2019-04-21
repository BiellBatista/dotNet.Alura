using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosController
    {
        private static string CarregaLista(IEnumerable<Livro> livros)
        {
            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("para-ler");

            foreach (var livro in livros)
                conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM#", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVO-ITEM#");
            conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM#", "");
            return conteudoArquivo;
        }

        public static Task Lendo(HttpContext context)
        {
            // esrevendo a lista de livros
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lendo.ToString());
        }

        public static Task Lidos(HttpContext context)
        {
            // esrevendo a lista de livros
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lidos.ToString());
        }

        // Toda informação do HTTP é encapsulada na calsse HttpContext
        public IActionResult ParaLer()
        {
            var _repo = new LivroRepositorioCSV();
            //var html = CarregaLista(_repo.ParaLer.Livros);
            var html = new ViewResult { ViewName = "para-ler" };
            return html;

            // esrevendo a lista de livros
            //var _repo = new LivroRepositorioCSV();
            //return context.Response.WriteAsync(_repo.ParaLer.ToString());
        }
        /*
         * o compilador ignora os modificadores (public, private, protected...) na avaliação de um delegate.
         * 
         * Escolha a alternativa com a melhor definição para Request Pipeline.
         * 
         * Termo usado pelo ASP.NET Core para representar o fluxo que uma requisição HTTP percorre dentro de sua aplicação até que a resposta seja entregue ao cliente.
         * O código que escrevemos nesse pipeline é chamado Middleware.
         */
        public string Detalhes(int id)
        {
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(l => l.Id == id);
            return livro.Detalhes();
        }

        public string Teste()
        {
            return "Nova funcionalidade foi implementada";
        }
    }
}
