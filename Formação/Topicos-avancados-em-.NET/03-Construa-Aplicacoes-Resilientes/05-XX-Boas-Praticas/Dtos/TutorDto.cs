using _05_XX_Boas_Praticas.Models;

namespace _05_XX_Boas_Praticas.Dtos;

public record TutorDto(long Id, string Nome, string Email)
{
    public TutorDto(Tutor tutor) : this(tutor.Id, tutor.Nome, tutor.Email)
    {
    }
}