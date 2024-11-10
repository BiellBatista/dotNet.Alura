using System.ComponentModel.DataAnnotations;

namespace _02_XX_Excecoes_ADOPET_API.Dtos;
public record CadastroTutorDto
{
    [Required]
    public string Nome { get; init; }

    [Required]
    public string Email { get; init; }
}