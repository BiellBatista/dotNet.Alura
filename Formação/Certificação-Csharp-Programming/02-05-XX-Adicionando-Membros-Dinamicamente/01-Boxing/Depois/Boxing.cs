using System;

namespace _02_05_XX_Adicionando_Membros_Dinamicamente.Depois
{
    class Boxing : IAulaItem
    {
        public void Executar()
        {
            int numero = 57;

            object caixa = numero;

            Console.WriteLine(string.Concat("Resposta", numero, true));
        }
    }
}
