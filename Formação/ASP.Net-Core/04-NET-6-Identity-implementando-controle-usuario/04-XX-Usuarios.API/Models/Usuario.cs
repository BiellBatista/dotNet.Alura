using Microsoft.AspNetCore.Identity;

namespace _04_XX_Usuarios.API.Models;

public class Usuario : IdentityUser
{
    public DateTime DataNascimento { get; set; }

    public Usuario() : base()
    {
    }
}