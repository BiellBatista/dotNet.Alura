﻿using System;

namespace _02_05_XX_Adicionando_Membros_Dinamicamente.Depois
{
    internal class Unboxing : IAulaItem
    {
        public void Executar()
        {
            int numero = 57;      // tipo de valor
            object caixa = numero;

            try
            {
                int unboxed = (int)caixa; //o casting deve ser do mesmo tipo. Ou seja, não posso fazer int x = (short) y;

                Console.WriteLine("Unboxing Ok.");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Erro: unboxing incorreto.", e);
            }
        }
    }
}