using System.ComponentModel.DataAnnotations;

namespace _03_XX_Lançando_Excecoes.Dtos;

public record AprovarAdocaoDto
{
    [Required]
    public long IdAdocao { get; init; }
}