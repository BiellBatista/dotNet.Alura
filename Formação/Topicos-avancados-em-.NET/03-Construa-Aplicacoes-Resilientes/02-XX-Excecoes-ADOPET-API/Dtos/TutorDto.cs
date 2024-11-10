using _02_XX_Excecoes_ADOPET_API.Models;

namespace _02_XX_Excecoes_ADOPET_API.Dtos;

public record TutorDto(long Id, string Nome, string Email)
{
    public TutorDto(Tutor tutor) : this(tutor.Id, tutor.Nome, tutor.Email)
    {
    }
}