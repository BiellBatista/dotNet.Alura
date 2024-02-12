using FluentResults;

namespace _03_04_XX_Entendendo_OCP.Console.Comandos
{
    public interface IComando
    {
        Task<Result> ExecutarAsync();
    }
}