﻿using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using System;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraFilmesContexto())
            {
                contexto.LogSQLToConsole();
                Console.ReadLine();
            }
        }
    }
}
