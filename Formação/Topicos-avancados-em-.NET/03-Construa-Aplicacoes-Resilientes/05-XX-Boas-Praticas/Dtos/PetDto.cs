using _05_XX_Boas_Praticas.Models;
using _05_XX_Boas_Praticas.Models.Enums;

namespace _05_XX_Boas_Praticas.Dtos;

public record PetDto(long Id, string Nome, int Idade, TipoPet Tipo, bool Adotado, string Imagem)
{
    public PetDto(Pet pet) : this(pet.Id, pet.Nome, pet.Idade, pet.Tipo, pet.Adotado, pet.Imagem)
    {
    }
}