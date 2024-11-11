using System.ComponentModel.DataAnnotations;

namespace _04_XX_Hierarquia_Excecoes.Dtos;
public record CadastroTutorDto
{
    [Required]
    public string Nome { get; init; }

    [Required]
    public string Email { get; init; }
}