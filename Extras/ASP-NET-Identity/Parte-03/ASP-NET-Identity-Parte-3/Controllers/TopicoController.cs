using ASP_NET_Identity_Parte_3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_Identity_Parte_3.Controllers
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