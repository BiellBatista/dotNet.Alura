using System.ComponentModel.DataAnnotations;

namespace _02_XX_Filmes.API.Models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }

    public string Logradouro { get; set; }

    public int Numero { get; set; }
    
    public virtual Cinema Cinema { get; set; }
}