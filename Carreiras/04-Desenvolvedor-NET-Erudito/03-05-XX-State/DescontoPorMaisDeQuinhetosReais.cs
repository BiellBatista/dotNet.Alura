﻿namespace _03_05_XX_State
{
    public class DescontoPorMaisDeQuinhetosReais : IDesconto
    {
        public IDesconto Proximo { get; set; }

        public double Desconta(Orcamento orcamento)
        {
            if (orcamento.Valor > 500.0)
            {
                return orcamento.Valor * 0.07;
            }

            return Proximo.Desconta(orcamento);
        }
    }
}
