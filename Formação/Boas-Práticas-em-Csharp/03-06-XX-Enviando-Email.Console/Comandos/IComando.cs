﻿using FluentResults;

namespace _03_06_XX_Enviando_Email.Console.Comandos
{
    public interface IComando
    {
        Task<Result> ExecutarAsync();
    }
}