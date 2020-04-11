using _06_04_XX_CasaDoCodigo.Models;
using Microsoft.AspNetCore.Mvc;

namespace _06_04_XX_CasaDoCodigo.Areas.Catalogo.ViewComponents
{
    public class ProdutoCardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Produto produto)
        {
            return View("Default", produto);
        }
    }
}
