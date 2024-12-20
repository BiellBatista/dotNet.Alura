using System.ComponentModel.DataAnnotations;

namespace _01_XX_Item.Service.Models;

public class Restaurante
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public int IdExterno { get; set; }

    [Required]
    public string Nome { get; set; }

    public ICollection<Item> Itens { get; set; } = new List<Item>();
}