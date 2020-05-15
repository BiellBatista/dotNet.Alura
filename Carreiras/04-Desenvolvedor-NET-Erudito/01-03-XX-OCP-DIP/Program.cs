using System;
using System.Collections.Generic;

namespace _01_03_XX_OCP_DIP
{
    class Program
    {
        static void Main(string[] args)
        {
            EnviadorDeEmail enviadorDeEmail = new EnviadorDeEmail();
            NotaFiscalDao nfDao = new NotaFiscalDao();
            SAP sap = new SAP();
            IList<IAcaoAposGerarNota> acoes = new List<IAcaoAposGerarNota>();
            acoes.Add(enviadorDeEmail);
            acoes.Add(nfDao);
            acoes.Add(sap);
            GeradorDeNotaFiscal gnf = new GeradorDeNotaFiscal(acoes);
            Fatura fatura = new Fatura(200, "Gabriel Batista");

            gnf.Gerar(fatura);
            Console.ReadLine();
        }
    }
}
