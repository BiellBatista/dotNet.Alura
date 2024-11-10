using System.ComponentModel.DataAnnotations;

namespace _01_XX_Conhecendo_Excecoes.Dtos;
public record CadastroTutorDto
{
    [Required]
    public string Nome { get; init; }

    [Required]
    public string Email { get; init; }
}