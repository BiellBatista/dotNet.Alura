using System.ComponentModel.DataAnnotations;

namespace _04_02_XX_Autenticacao_APP_Web.Web.Requests;
public record ArtistaRequest([Required] string nome, [Required] string bio, string? fotoPerfil);