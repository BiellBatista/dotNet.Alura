using System.ComponentModel.DataAnnotations;

namespace _04_XX_Usuarios.API.Data.Dtos;

public class LoginUsuarioDto
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}