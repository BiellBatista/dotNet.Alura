﻿using FluentResults;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Comandos
{
    public interface IComando
    {
        Task<Result> ExecutarAsync();
    }
}