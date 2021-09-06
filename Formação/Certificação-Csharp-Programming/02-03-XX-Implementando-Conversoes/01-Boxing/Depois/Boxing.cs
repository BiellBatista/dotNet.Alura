using System;

namespace _02_03_XX_Implementando_Conversoes.Depois
{
    internal class Boxing : IAulaItem
    {
        public void Executar()
        {
            int numero = 57;

            object caixa = numero;

            Console.WriteLine(string.Concat("Resposta", numero, true));
        }
    }
}