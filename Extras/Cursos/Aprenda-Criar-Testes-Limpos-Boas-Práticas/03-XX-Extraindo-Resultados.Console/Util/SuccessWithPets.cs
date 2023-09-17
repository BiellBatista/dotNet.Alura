using _03_XX_Extraindo_Resultados.Console.Modelos;

namespace _03_XX_Extraindo_Resultados.Console.Util
{
    public class SuccessWithPets : Success
    {
        public IEnumerable<Pet> Data { get; }

        public SuccessWithPets(IEnumerable<Pet> data)
        {
            Data = data;
        }
    }
}