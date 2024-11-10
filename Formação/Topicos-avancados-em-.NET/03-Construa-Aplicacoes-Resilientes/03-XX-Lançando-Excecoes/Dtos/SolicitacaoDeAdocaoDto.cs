using System.ComponentModel.DataAnnotations;

namespace _03_XX_Lançando_Excecoes.Dtos;

public record SolicitacaoDeAdocaoDto
{
    [Required]
    public long IdPet { get; init; }

    [Required]
    public long IdTutor { get; init; }

    [Required]
    public string Motivo { get; init; }
}