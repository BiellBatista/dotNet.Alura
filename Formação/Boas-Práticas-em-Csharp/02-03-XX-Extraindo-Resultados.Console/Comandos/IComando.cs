﻿using FluentResults;

namespace _02_03_XX_Extraindo_Resultados.Console.Comandos
{
    internal interface IComando
    {
        Task<Result> ExecutarAsync(string[] args);
    }
}