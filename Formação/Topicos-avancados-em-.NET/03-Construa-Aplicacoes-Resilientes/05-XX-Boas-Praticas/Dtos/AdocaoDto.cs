using _05_XX_Boas_Praticas.Models;
using _05_XX_Boas_Praticas.Models.Enums;

namespace _05_XX_Boas_Praticas.Dtos;

public record AdocaoDto(long Id, long Tutor, long Pet, string Motivo, StatusAdocao Status, string Justificativa)
{
    public AdocaoDto(Adocao adocao) : this(adocao.Id, adocao.Tutor.Id, adocao.Pet.Id, adocao.Motivo, adocao.Status, adocao.Justificativa)
    {
    }
}