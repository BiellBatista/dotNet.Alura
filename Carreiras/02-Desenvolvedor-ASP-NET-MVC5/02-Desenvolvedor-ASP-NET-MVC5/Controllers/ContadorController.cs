using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02_Desenvolvedor_ASP_NET_MVC5.Controllers
{
    public class ContadorController : Controller
    {
        // GET: Contador
        public ActionResult Index()
        {
            var valorNaSession = Session["contador"];
            int contador = Convert.ToInt32(valorNaSession);
            contador++;
            Session["contador"] = contador;
            return View(contador);
        }
    }
}

/*
 * A Session do Asp.Net MVC funciona como um IDictionary<string, object> do C#, então a busca de uma chave armazenada sempre devolve um valor do tipo object. Mesmo quando armazenamos um valor do tipo int.
 */
