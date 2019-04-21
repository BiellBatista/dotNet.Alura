using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class CadastroLogica
    {
        public static Task ProcessaFormulario(HttpContext context)
        {
            var livro = new Livro()
            {
                //Titulo = context.Request.Query["titulo"].First(), //pegando o valor da queryString (?titulo=X)
                //Autor = context.Request.Query["autor"].First() //pegando o valor da queryString (?titulo=X&autor=X)
                Titulo = context.Request.Form["titulo"].First(), //pegando o valor na requisição (método POST), é a propriedade FORM que faz isso
                Autor = context.Request.Form["autor"].First() //pegando o valor na requisição (método POST)
            };
            var repo = new LivroRepositorioCSV();

            repo.Incluir(livro);

            return context.Response.WriteAsync("O livro foi adicionado com sucesso");
        }

        public static Task ExibeFormulario(HttpContext context)
        {
            var html = HtmlUtils.CarregaArquivoHTML("formulario");
            return context.Response.WriteAsync(html);
        }

        public static Task NovoLivroParaLer(HttpContext context)
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
    }
}
