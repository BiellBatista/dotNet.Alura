using System;

namespace _03_01_XX_Strategy
{
    public class CalculadorDeImpostos
    {
        // versão velha
        //public void RealizaCalculo(Orcamento orcamento, string imposto)
        //{
        //    //posso usar o ICMS em vez do imposto para o método Equals, pois o imposto pode ser nulo
        //    if ("ICMS".Equals(imposto))
        //    {
        //        double icms = new ICMS().CalculaICMS(orcamento);
        //        Console.WriteLine(icms);
        //    }
        //    else if ("ISS".Equals(imposto))
        //    {
        //        double iss = new ISS().CalculaISS(orcamento);
        //        Console.WriteLine(iss);
        //    }
        //}

        public void RealizaCalculo(Orcamento orcamento, Imposto imposto)
        {
            double valor = imposto.Calcula(orcamento);
            Console.WriteLine(valor);
        }
    }
}
