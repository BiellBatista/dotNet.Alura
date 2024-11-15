using System.ComponentModel.DataAnnotations;

namespace _03_XX_Restaurante.Service.Models;

public class Restaurante
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Endereco { get; set; }

    [Required]
    public string Site { get; set; }
}