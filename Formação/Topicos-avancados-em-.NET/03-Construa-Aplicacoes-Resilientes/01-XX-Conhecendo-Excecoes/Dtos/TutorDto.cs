using _01_XX_Conhecendo_Excecoes.Models;

namespace _01_XX_Conhecendo_Excecoes.Dtos;

public record TutorDto(long Id, string Nome, string Email)
{
    public TutorDto(Tutor tutor) : this(tutor.Id, tutor.Nome, tutor.Email)
    {
    }
}