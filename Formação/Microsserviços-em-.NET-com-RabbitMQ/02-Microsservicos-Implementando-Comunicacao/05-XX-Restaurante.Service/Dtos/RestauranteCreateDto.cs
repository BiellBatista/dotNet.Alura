using System.ComponentModel.DataAnnotations;

namespace _05_XX_Restaurante.Service.Dtos;

public class RestauranteCreateDto
{
    [Required]
    public string Nome { get; set; }

    [Required]
    public string Endereco { get; set; }

    [Required]
    public string Site { get; set; }
}