using System;

namespace _01_03_XX_OCP_DIP
{
    class NotaFiscalDao : IAcaoAposGerarNota
    {
        public void Executar(NotaFiscal nf)
        {
            Console.WriteLine("Persistindo nota");
        }
    }
}
