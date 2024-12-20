﻿using _06_04_XX_CasaDoCodigo.Models;
using System.Collections.Generic;

namespace _06_04_XX_CasaDoCodigo.Areas.Catalogo.Models.ViewModels
{
    public class CarrosselPaginaViewModel
    {
        public CarrosselPaginaViewModel(IList<Produto> produtos, int indice)
        {
            Produtos = produtos;
            Indice = indice;
        }

        public IList<Produto> Produtos { get; set; }
        public int Indice { get; set; }
    }
}
