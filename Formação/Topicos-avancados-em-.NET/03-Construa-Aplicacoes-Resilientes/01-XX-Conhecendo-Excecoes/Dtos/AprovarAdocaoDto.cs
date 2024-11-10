using System.ComponentModel.DataAnnotations;

namespace _01_XX_Conhecendo_Excecoes.Dtos;

public record AprovarAdocaoDto
{
    [Required]
    public long IdAdocao { get; init; }
}