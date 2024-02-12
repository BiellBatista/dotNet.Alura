using _03_03_XX_Importacao_Clientes.Console.Modelos;
using FluentResults;

namespace _03_03_XX_Importacao_Clientes.Console.Results;

public class SuccessWithClientes : Success
{
    public SuccessWithClientes(IEnumerable<Cliente> data, string mensagem) : base(mensagem)
    {
        Data = data;
    }

    public IEnumerable<Cliente> Data { get; }
}