using _03_XX_Lançando_Excecoes.Models;

namespace _03_XX_Lançando_Excecoes.Dtos;

public record TutorDto(long Id, string Nome, string Email)
{
    public TutorDto(Tutor tutor) : this(tutor.Id, tutor.Nome, tutor.Email)
    {
    }
}