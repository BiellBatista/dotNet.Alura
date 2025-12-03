using FluentResults;

namespace _03_02_XX_Preparando_Importacao_Clientes.Console.Comandos
{
    public interface IComando
    {
        Task<Result> ExecutarAsync();
    }
}