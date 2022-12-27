using System.ComponentModel.DataAnnotations;

namespace _05_XX_Item.Service.Dtos;

public class ItemCreateDto
{
    [Required]
    public string Nome { get; set; }

    [Required]
    public double Preco { get; set; }
}