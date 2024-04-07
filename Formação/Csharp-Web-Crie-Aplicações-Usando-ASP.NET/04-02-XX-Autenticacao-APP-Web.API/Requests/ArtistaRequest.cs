using System.ComponentModel.DataAnnotations;

namespace _04_02_XX_Autenticacao_APP_Web.API.Requests;
public record ArtistaRequest([Required] string nome, [Required] string bio, string? fotoPerfil);