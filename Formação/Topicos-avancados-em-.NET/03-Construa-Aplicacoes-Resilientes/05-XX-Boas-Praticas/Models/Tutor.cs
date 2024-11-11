using _05_XX_Boas_Praticas.Dtos;
using System.ComponentModel.DataAnnotations;

namespace _05_XX_Boas_Praticas.Models;

public class Tutor
{
    [Key]
    [Required]
    public long Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Email { get; set; }

    public virtual List<Adocao> Adocoes { get; set; }

    public Tutor()
    {
    }

    public Tutor(CadastroTutorDto dados)
    {
        Nome = dados.Nome;
        Email = dados.Email;
    }
}