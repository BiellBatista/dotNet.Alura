using _04_XX_Usuarios.API.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _04_XX_Usuarios.API.Services;

public class TokenService
{
    public string GenerateToken(Usuario usuario)
    {
        var claims = new Claim[]
        {
                new("username", usuario.UserName),
                new("id", usuario.Id),
                new(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString()),
                new("loginTimestamp", DateTime.UtcNow.ToString())
        };

        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("9ASHDA98H9ah9ha9H9A89n0f"));
        var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddMinutes(10),
            claims: claims,
            signingCredentials: signingCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}