using System.ComponentModel.DataAnnotations;

namespace _05_XX_Boas_Praticas.Dtos;
public record CadastroTutorDto
{
    [Required]
    public string Nome { get; init; }

    [Required]
    public string Email { get; init; }
}