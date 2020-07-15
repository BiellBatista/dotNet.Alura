using System;

namespace _03_07_XX_Observer
{
    public class EnviadorDeSms : IAcaoAposGerarNota
    {
        public void Executa(NotaFiscal notaFiscal)
        {
            Console.WriteLine("enviando por sms");
        }
    }
}
