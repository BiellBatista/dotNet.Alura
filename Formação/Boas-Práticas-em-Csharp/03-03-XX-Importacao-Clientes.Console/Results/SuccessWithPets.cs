using _03_03_XX_Importacao_Clientes.Console.Modelos;
using FluentResults;

namespace _03_03_XX_Importacao_Clientes.Console.Results;

public class SuccessWithPets : Success
{
    public IEnumerable<Pet> Data { get; }

    public SuccessWithPets(IEnumerable<Pet> data, string mensagem) : base(mensagem)
    {
        Data = data;
    }
}