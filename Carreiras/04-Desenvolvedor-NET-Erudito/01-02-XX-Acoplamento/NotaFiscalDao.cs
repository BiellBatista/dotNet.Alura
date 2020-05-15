using System;

namespace _01_02_XX_Acoplamento
{
    class NotaFiscalDao : IAcaoAposGerarNota
    {
        public void Executar(NotaFiscal nf)
        {
            Console.WriteLine("Persistindo nota");
        }
    }
}
