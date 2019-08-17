using LojaRazor.DAO;
using System.Web.Mvc;

namespace LojaRazor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ProdutosDAO produtosDAO = new ProdutosDAO();
            ViewBag.Produtos = produtosDAO.Ofertas();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contato()
        {
            return View();
        }
    }
}
