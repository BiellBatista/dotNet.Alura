using Microsoft.AspNetCore.Identity;

namespace _02_XX_Usuarios.API.Models;

public class Usuario : IdentityUser
{
    public DateTime DataNascimento { get; set; }

    public Usuario() : base()
    {
    }
}