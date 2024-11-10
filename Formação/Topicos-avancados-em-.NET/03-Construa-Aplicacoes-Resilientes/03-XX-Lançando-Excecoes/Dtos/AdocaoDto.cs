using _03_XX_Lançando_Excecoes.Models;
using _03_XX_Lançando_Excecoes.Models.Enums;

namespace _03_XX_Lançando_Excecoes.Dtos;

public record AdocaoDto(long Id, long Tutor, long Pet, string Motivo, StatusAdocao Status, string Justificativa)
{
    public AdocaoDto(Adocao adocao) : this(adocao.Id, adocao.Tutor.Id, adocao.Pet.Id, adocao.Motivo, adocao.Status, adocao.Justificativa)
    {
    }
}