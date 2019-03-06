using _02_Desenvolvedor_ASP_NET_MVC5.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _02_Desenvolvedor_ASP_NET_MVC5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            // toda vez que eu subir uma aplicação ele irá executar esse cara que irá adicionar o filtro configurado no arquivo FilterConfig.cs
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
