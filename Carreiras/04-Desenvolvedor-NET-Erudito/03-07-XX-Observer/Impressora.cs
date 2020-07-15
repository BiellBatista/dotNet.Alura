using System;

namespace _03_07_XX_Observer
{
    public class Impressora : IAcaoAposGerarNota
    {
        public void Executa(NotaFiscal notaFiscal)
        {
            Console.WriteLine("imprimindo notaFiscal");
        }
    }
}
