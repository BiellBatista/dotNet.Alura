using _06_04_XX_CasaDoCodigo.Areas.Catalogo.Models.ViewModels;
using _06_04_XX_CasaDoCodigo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_04_XX_CasaDoCodigo.Areas.Catalogo.ViewComponents
{
    public class CarrosselViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Categoria categoria, IList<Produto> produtos, int tamanhoPagina)
        {
            var produtosNaCategoria =
                produtos
                .Where(p => p.Categoria.Id == categoria.Id)
                .ToList();

            int paginas = (int)Math.Ceiling((double)produtosNaCategoria.Count() / tamanhoPagina);

            return View("Default",
                new CarrosselViewModel(categoria, produtosNaCategoria, paginas, tamanhoPagina));
        }
    }
}
