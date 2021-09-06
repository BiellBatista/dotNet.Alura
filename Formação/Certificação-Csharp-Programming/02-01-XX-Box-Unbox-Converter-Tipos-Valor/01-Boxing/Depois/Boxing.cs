using System;

namespace _02_01_XX_Box_Unbox_Converter_Tipos_Valor.Depois
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