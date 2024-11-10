using _02_XX_Excecoes_ADOPET_API.Models;
using _02_XX_Excecoes_ADOPET_API.Models.Enums;

namespace _02_XX_Excecoes_ADOPET_API.Dtos;

public record AdocaoDto(long Id, long Tutor, long Pet, string Motivo, StatusAdocao Status, string Justificativa)
{
    public AdocaoDto(Adocao adocao) : this(adocao.Id, adocao.Tutor.Id, adocao.Pet.Id, adocao.Motivo, adocao.Status, adocao.Justificativa)
    {
    }
}