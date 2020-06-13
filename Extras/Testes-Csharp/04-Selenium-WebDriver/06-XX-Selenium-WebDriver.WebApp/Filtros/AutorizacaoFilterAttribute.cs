using Microsoft.AspNetCore.Mvc.Filters;
using _06_XX_Selenium_WebDriver.WebApp.Extensions;
using _06_XX_Selenium_WebDriver.Core;
using Microsoft.AspNetCore.Mvc;

namespace _06_XX_Selenium_WebDriver.WebApp.Filtros
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var usuarioLogado = context.HttpContext.Session.Get<Usuario>("usuarioLogado");
            if (usuarioLogado == null)
            {
                context.Result = new RedirectToActionResult("Login", "Autenticacao", null);
            }
        }
    }
}
