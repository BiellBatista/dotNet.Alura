using _04_XX_Hierarquia_Excecoes.Models;
using _04_XX_Hierarquia_Excecoes.Models.Enums;

namespace _04_XX_Hierarquia_Excecoes.Dtos;

public record AdocaoDto(long Id, long Tutor, long Pet, string Motivo, StatusAdocao Status, string Justificativa)
{
    public AdocaoDto(Adocao adocao) : this(adocao.Id, adocao.Tutor.Id, adocao.Pet.Id, adocao.Motivo, adocao.Status, adocao.Justificativa)
    {
    }
}