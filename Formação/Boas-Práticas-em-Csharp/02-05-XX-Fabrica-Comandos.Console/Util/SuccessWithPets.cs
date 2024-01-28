using _05_XX_Fabrica_Comandos.Console.Modelos;
using FluentResults;

namespace _05_XX_Fabrica_Comandos.Console.Util
{
    public class SuccessWithPets : Success
    {
        public IEnumerable<Pet> Data { get; }

        public SuccessWithPets(IEnumerable<Pet> data, string mensagem) : base(mensagem)
        {
            Data = data;
        }
    }
}