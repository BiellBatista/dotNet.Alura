using _02_XX_Excecoes_ADOPET_API.Models;
using _02_XX_Excecoes_ADOPET_API.Models.Enums;

namespace _02_XX_Excecoes_ADOPET_API.Dtos;

public record PetDto(long Id, string Nome, int Idade, TipoPet Tipo, bool Adotado, string Imagem)
{
    public PetDto(Pet pet) : this(pet.Id, pet.Nome, pet.Idade, pet.Tipo, pet.Adotado, pet.Imagem)
    {
    }
}