using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace _05_XX_Boas_Praticas.Dtos;

public record ReprovarAdocaoDto
{
    [Required]
    [JsonPropertyName("idAdocao")]
    public long IdAdocao { get; init; }

    [Required]
    [StringLength(int.MaxValue, MinimumLength = 1)]
    [JsonPropertyName("justificativa")]
    public string Justificativa { get; init; }
}