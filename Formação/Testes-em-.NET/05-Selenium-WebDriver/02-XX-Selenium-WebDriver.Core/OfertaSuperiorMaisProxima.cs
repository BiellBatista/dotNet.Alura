﻿using System.Linq;

namespace _02_XX_Selenium_WebDriver.Core
{
    public class OfertaSuperiorMaisProxima : IModalidadeAvaliacao
    {
        public double ValorDestino { get; }

        public OfertaSuperiorMaisProxima(double valorDestino)
        {
            ValorDestino = valorDestino;
        }

        public Lance Avalia(Leilao leilao)
        {
            return leilao.Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .Where(l => l.Valor > ValorDestino)
                .OrderBy(l => l.Valor)
                .FirstOrDefault();
        }
    }
}
