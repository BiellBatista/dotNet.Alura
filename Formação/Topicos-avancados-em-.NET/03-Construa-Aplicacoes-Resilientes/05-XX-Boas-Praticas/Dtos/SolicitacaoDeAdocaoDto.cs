using System.ComponentModel.DataAnnotations;

namespace _05_XX_Boas_Praticas.Dtos;

public record SolicitacaoDeAdocaoDto
{
    [Required]
    public long IdPet { get; init; }

    [Required]
    public long IdTutor { get; init; }

    [Required]
    public string Motivo { get; init; }
}