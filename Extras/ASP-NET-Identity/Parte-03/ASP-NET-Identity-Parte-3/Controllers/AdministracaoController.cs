using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_Identity_Parte_3.Controllers
{
    //avisando que apenas administrador pode acessar esta página
    [Authorize(Roles = RolesName.ADMINISTRADOR)]
    public class AdministracaoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}