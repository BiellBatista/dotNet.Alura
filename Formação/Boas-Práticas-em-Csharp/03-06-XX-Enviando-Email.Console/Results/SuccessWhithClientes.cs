using _03_06_XX_Enviando_Email.Console.Modelos;
using FluentResults;

namespace _03_06_XX_Enviando_Email.Console.Results;

public class SuccessWithClientes : Success
{
    public SuccessWithClientes(IEnumerable<Cliente> data, string mensagem) : base(mensagem)
    {
        Data = data;
    }

    public IEnumerable<Cliente> Data { get; }
}