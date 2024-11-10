using _01_XX_Conhecendo_Excecoes.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace _01_XX_Conhecendo_Excecoes.Dtos;

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