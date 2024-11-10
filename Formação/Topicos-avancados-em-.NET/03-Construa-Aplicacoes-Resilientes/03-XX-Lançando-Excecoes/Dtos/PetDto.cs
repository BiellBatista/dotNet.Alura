using _03_XX_Lançando_Excecoes.Models;
using _03_XX_Lançando_Excecoes.Models.Enums;

namespace _03_XX_Lançando_Excecoes.Dtos;

public record PetDto(long Id, string Nome, int Idade, TipoPet Tipo, bool Adotado, string Imagem)
{
    public PetDto(Pet pet) : this(pet.Id, pet.Nome, pet.Idade, pet.Tipo, pet.Adotado, pet.Imagem)
    {
    }
}