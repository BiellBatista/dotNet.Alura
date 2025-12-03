using _03_01_XX_Importando_Json.Console.Modelos;
using FluentResults;

namespace _03_01_XX_Importando_Json.Console.Results;

public class SuccessWithPets : Success
{
    public IEnumerable<Pet> Data { get; }

    public SuccessWithPets(IEnumerable<Pet> data, string mensagem) : base(mensagem)
    {
        Data = data;
    }
}