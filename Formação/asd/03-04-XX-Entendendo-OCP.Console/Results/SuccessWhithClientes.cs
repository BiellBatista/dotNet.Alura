using _03_04_XX_Entendendo_OCP.Console.Modelos;
using FluentResults;

namespace _03_04_XX_Entendendo_OCP.Console.Results;

public class SuccessWithClientes : Success
{
    public SuccessWithClientes(IEnumerable<Cliente> data, string mensagem) : base(mensagem)
    {
        Data = data;
    }

    public IEnumerable<Cliente> Data { get; }
}