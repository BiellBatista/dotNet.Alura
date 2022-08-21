using System.ComponentModel.DataAnnotations;

namespace _04_XX_Item.Service.Dtos;

public class ItemCreateDto
{
    [Required]
    public string Nome { get; set; }

    [Required]
    public double Preco { get; set; }
}