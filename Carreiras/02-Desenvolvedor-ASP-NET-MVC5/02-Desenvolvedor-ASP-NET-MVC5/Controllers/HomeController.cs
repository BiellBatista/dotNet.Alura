using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02_Desenvolvedor_ASP_NET_MVC5.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // código da regra de negócio
            return View();
            /*
             * O View(); é responsável por gerar o HTML da página.
             * A View que cuida deste método, possui o mesmo nome que o método
             */
        }
    }
}
/*
 * A rota padrão do MVC é o HomeController/Index
 */ 