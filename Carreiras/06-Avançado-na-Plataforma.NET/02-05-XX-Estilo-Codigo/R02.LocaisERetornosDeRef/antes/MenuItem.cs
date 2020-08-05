using System;
using static System.Console;

namespace _02_05_XX_Estilo_Codigo.R02.antes
{
    class MenuItem : _02_05_XX_Estilo_Codigo.MenuItem
    {
        public override void Main()
        {
            int[] numeros = { 2, 7, 1, 9, 12, 8, 15 };
            int indice = LocalizarIndice(12, numeros);
            numeros[indice] = -12;
            WriteLine(numeros[4]);
        }

        public int LocalizarIndice(int valor, int[] numeros)
        {
            for (int i = 0; i < numeros.Length; i++)
            {
                if (numeros[i] == valor)
                {
                    return i;
                }
            }

            throw new IndexOutOfRangeException("Não encontrado!");
        }
    }
}
