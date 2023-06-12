using System.ComponentModel.DataAnnotations;

namespace _05_XX_Usuarios.API.Data.Dtos;

public class CreateUsuarioDto
{
    [Required]
    public string Username { get; set; }

    [Required]
    public DateTime DataNascimento { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string RePassword { get; set; }
}