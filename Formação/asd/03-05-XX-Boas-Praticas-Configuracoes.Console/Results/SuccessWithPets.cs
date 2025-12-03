using _03_05_XX_Boas_Praticas_Configuracoes.Console.Modelos;
using FluentResults;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Results;

public class SuccessWithPets : Success
{
    public IEnumerable<Pet> Data { get; }

    public SuccessWithPets(IEnumerable<Pet> data, string mensagem) : base(mensagem)
    {
        Data = data;
    }
}