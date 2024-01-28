using FluentResults;

namespace _03_XX_Extraindo_Resultados.Console.Comandos
{
    internal interface IComando
    {
        Task<Result> ExecutarAsync(string[] args);
    }
}