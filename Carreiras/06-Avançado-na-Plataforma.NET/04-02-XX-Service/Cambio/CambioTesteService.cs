using System;

namespace _04_02_XX_Service.Cambio
{
    public class CambioTesteService : ICambioService
    {
        private readonly Random _random = new Random();
        public decimal Calcular(string moedaOrigem, string moedaDestino, decimal valor) =>
            valor * (decimal)_random.NextDouble();
    }
}
