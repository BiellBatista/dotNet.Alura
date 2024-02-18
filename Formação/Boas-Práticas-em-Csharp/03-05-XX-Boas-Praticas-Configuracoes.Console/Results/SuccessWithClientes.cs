using _03_05_XX_Boas_Praticas_Configuracoes.Console.Modelos;
using FluentResults;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Results;

public class SuccessWithClientes : Success
{
    public SuccessWithClientes(IEnumerable<Cliente> data, string message) : base(message)
    {
        Data = data;
    }

    public IEnumerable<Cliente> Data { get; }
}