using System.ComponentModel.DataAnnotations;

namespace _04_XX_Hierarquia_Excecoes.Dtos;

public record AprovarAdocaoDto
{
    [Required]
    public long IdAdocao { get; init; }
}