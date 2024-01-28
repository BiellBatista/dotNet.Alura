using FluentResults;

namespace _04_XX_Isolando_Exibicao.Console.Comandos
{
    internal interface IComando
    {
        Task<Result> ExecutarAsync(string[] args);
    }
}