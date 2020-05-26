using System;

namespace _05_XX_TDD_xUnit.Core
{
    public class Lance
    {
        public Interessada Cliente { get; }
        public double Valor { get; }

        public Lance(Interessada cliente, double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("O valor do lance deve ser igual ou maior que zero.");
            }

            Cliente = cliente;
            Valor = valor;
        }
    }
}
