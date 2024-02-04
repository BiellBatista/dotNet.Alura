using FluentResults;

namespace _03_01_XX_Importando_Json.Console.Comandos
{
    public interface IComando
    {
        Task<Result> ExecutarAsync();
    }
}