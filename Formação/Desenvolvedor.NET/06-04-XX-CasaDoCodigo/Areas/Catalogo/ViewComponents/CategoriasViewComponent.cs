using _06_04_XX_CasaDoCodigo.Areas.Catalogo.Models.ViewModels;
using _06_04_XX_CasaDoCodigo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace _06_04_XX_CasaDoCodigo.Areas.Catalogo.ViewComponents
{
    // este é o terceiro item necessário para construir uma ViewComponent
    // O primeiro é a ViewModel, o segundo a View.
    public class CategoriasViewComponent : ViewComponent
    {
        private const int TamanhoPagina = 4;

        public IViewComponentResult Invoke(IList<Produto> produtos)
        {
            var categorias =
                produtos
                .Select(m => m.Categoria)
                .Distinct()
                .ToList();

            return View("Default",
                new CategoriasViewModel(categorias, produtos, TamanhoPagina));
        }
    }
}
