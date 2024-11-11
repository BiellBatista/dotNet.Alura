using System.ComponentModel.DataAnnotations;

namespace _05_XX_Boas_Praticas.Dtos;

public record AprovarAdocaoDto
{
    [Required]
    public long IdAdocao { get; init; }
}