using _03_06_XX_Enviando_Email.Console.Modelos;
using FluentResults;

namespace _03_06_XX_Enviando_Email.Console.Results;

public class SuccessWithPets : Success
{
    public IEnumerable<Pet> Data { get; }

    public SuccessWithPets(IEnumerable<Pet> data, string mensagem) : base(mensagem)
    {
        Data = data;
    }
}