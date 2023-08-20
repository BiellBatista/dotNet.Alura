using System.ComponentModel.DataAnnotations;

namespace _03_XX_Melhorando_Legibilidade.API.Dominio;

public class Cliente
{
    public Cliente()
    {
        Id = Guid.NewGuid();
    }

    [Key]
    public Guid Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string CPF { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
    //public ICollection<Pet>? Pets { get; set; }
}