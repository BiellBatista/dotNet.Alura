using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _02_Desenvolvedor_ASP_NET_MVC5.DAO;
using _02_Desenvolvedor_ASP_NET_MVC5.Models;

namespace _02_Desenvolvedor_ASP_NET_MVC5.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            ProdutosDAO dao = new ProdutosDAO();
            IList<Produto> produtos = dao.Lista();
            // jogo o meu objeto para a cama de View com o atributo ViewBag
            ViewBag.Produtos = produtos;

            return View();
        }

        public ActionResult Form()
        {
            CategoriasDAO dao = new CategoriasDAO();
            IList<CategoriaDoProduto> categorias = dao.Lista();
            ViewBag.Categorias = categorias;
            return View();
        }

        ///*
        // * Para cada informação que eu quero pegar no formulário, devo colocar os parametros com o mesmo nome que estão no formulário
        // */ 
        //public ActionResult Adiciona(string nome, decimal preco, string descricao, int quantidade, int categoriaId)
        //{
        //    Produto produto = new Produto()
        //    {
        //        Nome = nome,
        //        Preco = preco,
        //        Descricao = descricao,
        //        Quantidade = quantidade,
        //        CategoriaId = categoriaId
        //    };

        //    ProdutosDAO dao = new ProdutosDAO();
        //    dao.Adiciona(produto);

        //    return View();
        //}

        /*
         * Este método faz a mesma coisa que o de cima. Porém, ele recebe um objeto do tipo produto e para isso ser possível, os input da view devem seguir uma regra no atributo name. 
         * Se eu usar o método de cim,a basta remover os trechos produto.... dos atributos names dos input.
         * O [HttpPost] faz com que o método só aceite dados vindo pelo POST
         */
        [HttpPost]
        public ActionResult Adiciona(Produto produto)
        {
            /*
             * O cara responsável por criar o modelo que será armazenado no banco de dados é chamado de Model Binder
             */
            ProdutosDAO dao = new ProdutosDAO();
            dao.Adiciona(produto);

            // redirecionando o usuário para o método index do controller produto. Posso omitir o controller, caso o método esteja invocando o próprio
            // Para redirecionar o usuário para uma action de outro controller, devemos utilizar a versão do RedirectToAction que recebe duas Strings, o nome da action e o nome do controller. Nesse caso, RedirectToAction("Index","Home").
            return RedirectToAction("Index", "Produto");
        }
    }
}
/* Aula 04
 * 
 * O Model Binder do ASP.NET MVC espera que os nomes dos parâmetros da requisição sejam da forma <Nome do Argumento do Controller>.<Nome do atributo>. Logo, nesse caso, devemos utilizar categoria.Id, além dessa convenção, o model binder do ASP.NET MVC também consegue preencher o modelo se enviarmos apenas o nome da propriedade, sem o nome do argumento da action, então também poderíamos enviar um parâmetro chamado Id para preencher a propriedade Id da categoria.

Como o model binder padrão não é case sensitive, as seguintes alternativas estão corretas: categoria.Id, categoria.ID e ID

Parabéns, você acertou!

 */
