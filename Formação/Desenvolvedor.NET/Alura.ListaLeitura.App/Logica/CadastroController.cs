using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Alura.ListaLeitura.App.Logica
{
    public class CadastroController
    {
        //O parametro diz para o Core construir um objeto do tipo livro
        public string Incluir(Livro livro)
        {
            //var livro = new Livro()
            //{
            //    //Titulo = context.Request.Query["titulo"].First(), //pegando o valor da queryString (?titulo=X)
            //    //Autor = context.Request.Query["autor"].First() //pegando o valor da queryString (?titulo=X&autor=X)
            //    Titulo = context.Request.Form["titulo"].First(), //pegando o valor na requisição (método POST), é a propriedade FORM que faz isso
            //    Autor = context.Request.Form["autor"].First() //pegando o valor na requisição (método POST)
            //};
            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);
            return "O livro foi adicionado com sucesso";
        }

        public IActionResult ExibeFormulario()
        {
            //var html = HtmlUtils.CarregaArquivoHTML("formulario");
            var html = new ViewResult { ViewName = "formulario" }; //classe que representa um resultado do tipo HTML e atribuindo o arquivo
            return html;
        }

        //public string NovoLivro(Livro livro)
        //{
        //    //var livro = new Livro()
        //    //{
        //    //    Titulo = context.GetRouteValue("nome").ToString(), //pegando o primeiro valor da rota
        //    //    Autor = context.GetRouteValue("autor").ToString() //pegando o segundo valor da rota
        //    //};
        //    var repo = new LivroRepositorioCSV();
        //    repo.Incluir(livro);
        //    return "O livro foi adicionado com sucesso";
        //}
    }
}
