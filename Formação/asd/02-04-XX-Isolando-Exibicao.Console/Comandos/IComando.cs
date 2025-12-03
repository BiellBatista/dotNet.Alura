using FluentResults;

namespace _02_04_XX_Isolando_Exibicao.Console.Comandos
{
    internal interface IComando
    {
        Task<Result> ExecutarAsync(string[] args);
    }
}