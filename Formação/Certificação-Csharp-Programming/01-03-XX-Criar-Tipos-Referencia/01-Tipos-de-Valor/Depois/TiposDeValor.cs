﻿using System;

namespace _01_03_XX_Criar_Tipos_Referencia.Depois
{
    internal class TiposDeValor : IAulaItem
    {
        public void Executar()
        {
            int idade;
            idade = 30;
            Console.WriteLine(idade);

            int copiaIdade = idade;

            Console.WriteLine($"idade: {idade}");
            Console.WriteLine($"copiaIdade: {copiaIdade}");

            idade = 23;

            Console.WriteLine($"idade: {idade}");
            Console.WriteLine($"copiaIdade: {copiaIdade}");

            int? idade2 = null;
            System.Nullable<int> idade3 = null;
        }
    }
}