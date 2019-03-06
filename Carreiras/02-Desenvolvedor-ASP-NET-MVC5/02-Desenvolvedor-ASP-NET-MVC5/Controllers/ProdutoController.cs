using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _02_Desenvolvedor_ASP_NET_MVC5.DAO;
using _02_Desenvolvedor_ASP_NET_MVC5.Filter;
using _02_Desenvolvedor_ASP_NET_MVC5.Models;

namespace _02_Desenvolvedor_ASP_NET_MVC5.Controllers
{
    // com esse attribute, ele será executado em todas as actions
    [AutorizacaoFilter] // chamando a classe de autorização. Ela será executada antes do método
    public class ProdutoController : Controller
    {
        // GET: Produto
        // personalizando a rota para acessar esta action
        // o segundo argumento serve para fixa um nome para a action
        [Route("produtos", Name = "ListaProdutos")]
        public ActionResult Index()
        {
            ProdutosDAO dao = new ProdutosDAO();
            IList<Produto> produtos = dao.Lista();
            // jogo o meu objeto para a cama de View com o atributo ViewBag
            ViewBag.Produtos = produtos;
            /*
             * Toda variável enviada fora da ViewBag é considerada como principal de uma view.
             * Envio a variável principal como argumento do método view
             */
            return View(produtos);
        }

        public ActionResult Form()
        {
            CategoriasDAO dao = new CategoriasDAO();
            IList<CategoriaDoProduto> categorias = dao.Lista();
            ViewBag.Categorias = categorias;
            /*
             * Devo fazer com a action Form envie um produto para a view, pois é necessário para preencher os campos
             */
            ViewBag.Produto = new Produto();
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
        [ValidateAntiForgeryToken] //usado junto com o token gerado no html
        public ActionResult Adiciona(Produto produto)
        {
            int idDaInformatica = 1;

            if (produto.CategoriaId.Equals(idDaInformatica) && produto.Preco < 100)
            {
                // colocando novo erro de validação
                ModelState.AddModelError("produto.Invalido", "Informática com preço abaixo de R$100,00");
            }

            /*
             * O cara responsável por criar o modelo que será armazenado no banco de dados é chamado de Model Binder
             */

            if (ModelState.IsValid)
            {
                ProdutosDAO dao = new ProdutosDAO();
                dao.Adiciona(produto);

                // redirecionando o usuário para o método index do controller produto. Posso omitir o controller, caso o método esteja invocando o próprio
                // Para redirecionar o usuário para uma action de outro controller, devemos utilizar a versão do RedirectToAction que recebe duas Strings, o nome da action e o nome do controller. Nesse caso, RedirectToAction("Index","Home").
                return RedirectToAction("Index", "Produto");
            }
            else
            {
                // retornando os dados que o usuário preencheu no campo. Assim, ao recarregar a página para mostrar os erros, os campos virão com os mesmos dados que foram preenchido pelo usuário
                ViewBag.Produto = produto;
                CategoriasDAO dao = new CategoriasDAO();
                ViewBag.Categorias = dao.Lista();
                return View("Form");
            }
        }

        // personalizando a rota. Tudo que estiver depois do / será um parâmetro
        [Route("produtos/{id}", Name = "VisualizaProduto")]
        // recebendo o id vindo da URL. Com isso, não preciso especificar o nome do atributo
        public ActionResult Visualiza(int id)
        {
            ProdutosDAO dao = new ProdutosDAO();
            Produto produto = dao.BuscaPorId(id);
            ViewBag.Produto = produto;
            return View();
        }

        public ActionResult DecrementaQtd(int id)
        {
            ProdutosDAO dao = new ProdutosDAO();
            Produto produto = dao.BuscaPorId(id);
            produto.Quantidade--;
            dao.Atualiza(produto);

            //return RedirectToAction("Index");
            // uso um Json para facilitar a requisição assicrono do AJAX (JQuery)
            return Json(produto);
        }
    }
}
/* Aula 04
 * 
 * O Model Binder do ASP.NET MVC espera que os nomes dos parâmetros da requisição sejam da forma <Nome do Argumento do Controller>.<Nome do atributo>. Logo, nesse caso, devemos utilizar categoria.Id, além dessa convenção, o model binder do ASP.NET MVC também consegue preencher o modelo se enviarmos apenas o nome da propriedade, sem o nome do argumento da action, então também poderíamos enviar um parâmetro chamado Id para preencher a propriedade Id da categoria.

Como o model binder padrão não é case sensitive, as seguintes alternativas estão corretas: categoria.Id, categoria.ID e ID

Parabéns, você acertou!

 */
