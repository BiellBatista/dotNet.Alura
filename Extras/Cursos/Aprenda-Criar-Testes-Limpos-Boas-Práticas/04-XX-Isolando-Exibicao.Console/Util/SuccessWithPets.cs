using _04_XX_Isolando_Exibicao.Console.Modelos;
using FluentResults;

namespace _04_XX_Isolando_Exibicao.Console.Util
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