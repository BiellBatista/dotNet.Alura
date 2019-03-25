using System.Web.Mvc;

namespace ASP_NET_Identity_Parte_4.Controllers
{
    [Authorize(Roles = RolesName.ADMINISTRADOR)]
    public class AdministracaoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}