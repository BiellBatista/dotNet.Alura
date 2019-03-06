using _02_Desenvolvedor_ASP_NET_MVC5.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02_Desenvolvedor_ASP_NET_MVC5.App_Start
{
    public class FilterConfig
    {
        // criando um filtro global para todas as páginas para ser declara dentro do arquivo Global.asax.cs
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new AutorizacaoFilterAttribute());
        }
    }
}

/*
 * O método do filtro que executa antes de uma action da aplicação é o OnActionExecuting.

Além do OnActionExecuting, temos também o OnActionExecuted (executado depois da action), OnResultExecuting (executado antes da view) e OnResultExecuted (executado depois da view).
*/