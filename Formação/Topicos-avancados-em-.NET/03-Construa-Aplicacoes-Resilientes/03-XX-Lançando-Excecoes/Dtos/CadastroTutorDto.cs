using System.ComponentModel.DataAnnotations;

namespace _03_XX_Lançando_Excecoes.Dtos;
public record CadastroTutorDto
{
    [Required]
    public string Nome { get; init; }

    [Required]
    public string Email { get; init; }
}