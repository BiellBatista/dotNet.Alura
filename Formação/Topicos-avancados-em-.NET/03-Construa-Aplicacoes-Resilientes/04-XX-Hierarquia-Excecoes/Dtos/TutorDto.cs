using _04_XX_Hierarquia_Excecoes.Models;

namespace _04_XX_Hierarquia_Excecoes.Dtos;

public record TutorDto(long Id, string Nome, string Email)
{
    public TutorDto(Tutor tutor) : this(tutor.Id, tutor.Nome, tutor.Email)
    {
    }
}