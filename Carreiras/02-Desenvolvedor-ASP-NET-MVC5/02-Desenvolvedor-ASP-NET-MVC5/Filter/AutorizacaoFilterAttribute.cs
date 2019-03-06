using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _02_Desenvolvedor_ASP_NET_MVC5.Filter
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        // sobrescrevendo um método que faz com que esta classe seja executada antes d euma action (método)
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // o HttpContext guarda os dados atuais das requisições que o ASP.NET MVC está tratando
            var usuario = filterContext.HttpContext.Session["usuarioLogado"]; // pegando o dados da chave X do dicionário Session

            if (usuario == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new
                    {
                        controller = "Login",
                        action = "Index"
                    })
                    );
            }
        }
    }
}

/*
 * Filtro para autorização
 */