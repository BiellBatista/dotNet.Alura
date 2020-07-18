using System;

namespace _04_09_XX_Facades_Singletons.Bridges
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
