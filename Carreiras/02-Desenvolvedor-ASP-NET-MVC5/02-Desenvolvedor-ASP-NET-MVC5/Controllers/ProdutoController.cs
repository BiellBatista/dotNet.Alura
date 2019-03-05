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
    }
}