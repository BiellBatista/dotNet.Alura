using FluentResults;

namespace _03_03_XX_Importacao_Clientes.Console.Comandos
{
    public interface IComando
    {
        Task<Result> ExecutarAsync();
    }
}