using _01_XX_Conhecendo_Excecoes.Models;
using _01_XX_Conhecendo_Excecoes.Models.Enums;

namespace _01_XX_Conhecendo_Excecoes.Dtos;

public record PetDto(long Id, string Nome, int Idade, TipoPet Tipo, bool Adotado, string Imagem)
{
    public PetDto(Pet pet) : this(pet.Id, pet.Nome, pet.Idade, pet.Tipo, pet.Adotado, pet.Imagem)
    {
    }
}