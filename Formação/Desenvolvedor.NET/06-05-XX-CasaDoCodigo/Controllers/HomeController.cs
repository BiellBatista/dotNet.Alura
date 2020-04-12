using Microsoft.AspNetCore.Mvc;

namespace _06_05_XX_CasaDoCodigo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/Catalogo");
        }
    }
}