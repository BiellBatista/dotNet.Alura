using _06_04_XX_CasaDoCodigo.Areas.Catalogo.Models.ViewModels;
using _06_04_XX_CasaDoCodigo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace _06_04_XX_CasaDoCodigo.Areas.Catalogo.ViewComponents
{
    public class CarrosselPaginaViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IList<Produto> produtosNaCategoria, int indicePagina, int tamanhoPagina)
        {
            var produtosNaPagina =
                produtosNaCategoria
                .Skip(indicePagina * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToList();

            return View("Default",
                new CarrosselPaginaViewModel(produtosNaPagina, indicePagina));
        }
    }
}
