﻿namespace _03_07_XX_Observer
{
    public class CalculadorDeDesconto
    {
        public double Calcula(Orcamento orcamento)
        {
            IDesconto d1 = new DescontoPorCincoItens();
            IDesconto d2 = new DescontoPorMaisDeQuinhetosReais();
            IDesconto d3 = new SemDesconto();


            d1.Proximo = d2;
            d2.Proximo = d3;

            return d1.Desconta(orcamento);
        }
    }
}
