﻿using System;

namespace _01_05_XX_Criar_Metodos_Sobrecarregados_Substituidos.Depois
{
    internal class Objetos : IAulaItem
    {
        public void Executar()
        {
            int pontuacao = 10;
            Console.WriteLine($"pontuacao: {pontuacao}");

            Console.WriteLine("OBJECT COM VALOR PRIMITIVO");
            object meuObjeto;
            meuObjeto = pontuacao;
            Console.WriteLine($"meuObjeto: {meuObjeto}");

            Console.WriteLine($"meuObjeto.GetType(): {meuObjeto.GetType()}");
            Console.WriteLine();
            Console.WriteLine("OBJECT COM REFERÊNCIA DE OBJETO");

            meuObjeto = new Jogador();
            Jogador classRef;
            classRef = (Jogador)meuObjeto; //conversão explícita, ou "cast"

            Console.WriteLine($"classRef.Pontuacao: {classRef.Pontuacao}");
        }
    }

    internal class Jogador
    {
        public int Pontuacao { get; set; } = 10;
    }
}