using System;

namespace _02_04_XX_Classe_Base.Depois
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
