using System;

namespace _04_06_XX_Bridges.Bridges
{
    public class EnviaPorEmail : IEnviador
    {
        public void Envia(IMensagem mensagem)
        {
            Console.WriteLine("Enviando a mensagem por E-mail");
            Console.WriteLine(mensagem.Formata());
        }
    }
}
