using System;

namespace _02_01_XX_Propriedades_Acessadores.Depois
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
