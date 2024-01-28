using FluentResults;

namespace _05_XX_Fabrica_Comandos.Console.Comandos
{
    internal interface IComando
    {
        Task<Result> ExecutarAsync();
    }
}