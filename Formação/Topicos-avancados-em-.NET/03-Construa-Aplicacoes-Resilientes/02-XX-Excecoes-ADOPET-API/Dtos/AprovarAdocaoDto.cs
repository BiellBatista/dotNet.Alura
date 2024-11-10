using System.ComponentModel.DataAnnotations;

namespace _02_XX_Excecoes_ADOPET_API.Dtos;

public record AprovarAdocaoDto
{
    [Required]
    public long IdAdocao { get; init; }
}