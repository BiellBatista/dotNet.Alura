using ASP_NET_Identity_Parte_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_Identity_Parte_1.Controllers
{
    public class ContaController : Controller
    {
        // GET: Conta
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ContaRegistrarViewModel modelo)
        {
            return View();
        }
    }
}