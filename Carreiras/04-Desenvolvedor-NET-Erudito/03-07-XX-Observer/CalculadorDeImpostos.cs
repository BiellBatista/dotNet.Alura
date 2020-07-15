using System;

namespace _03_07_XX_Observer
{
    public class CalculadorDeImpostos
    {
        public void RealizaCalculo(Orcamento orcamento, Imposto imposto)
        {
            double valor = imposto.Calcula(orcamento);
            Console.WriteLine(valor);
        }
    }
}
