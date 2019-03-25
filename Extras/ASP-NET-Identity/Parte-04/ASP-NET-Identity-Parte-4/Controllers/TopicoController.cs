using ASP_NET_Identity_Parte_4.ViewModels;
using System.Web.Mvc;

namespace ASP_NET_Identity_Parte_4.Controllers
{
    [Authorize]
    public class TopicoController : Controller
    {
        [HttpGet]
        public ActionResult Criar ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(TopicoCriarViewModel modelo)
        {
            return View();
        }
    }
}