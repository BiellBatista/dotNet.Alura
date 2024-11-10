using _01_XX_Conhecendo_Excecoes.Models;
using _01_XX_Conhecendo_Excecoes.Models.Enums;

namespace _01_XX_Conhecendo_Excecoes.Dtos;

public record AdocaoDto(long Id, long Tutor, long Pet, string Motivo, StatusAdocao Status, string Justificativa)
{
    public AdocaoDto(Adocao adocao) : this(adocao.Id, adocao.Tutor.Id, adocao.Pet.Id, adocao.Motivo, adocao.Status, adocao.Justificativa)
    {
    }
}