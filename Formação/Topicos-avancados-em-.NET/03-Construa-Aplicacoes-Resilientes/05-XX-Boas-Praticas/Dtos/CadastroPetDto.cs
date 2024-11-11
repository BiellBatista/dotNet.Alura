using _05_XX_Boas_Praticas.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace _05_XX_Boas_Praticas.Dtos;

public record CadastroPetDto
{
    [Required]
    public string Nome { get; set; }
    [Required]
    public int Idade { get; set; }
    [Required]
    public TipoPet Tipo { get; set; }
    [Required]
    public IFormFile Imagem { get; set; }
}