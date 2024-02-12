using _03_04_XX_Entendendo_OCP.Console.Modelos;
using FluentResults;

namespace _03_04_XX_Entendendo_OCP.Console.Results;

public class SuccessWithPets : Success
{
    public IEnumerable<Pet> Data { get; }

    public SuccessWithPets(IEnumerable<Pet> data, string mensagem) : base(mensagem)
    {
        Data = data;
    }
}