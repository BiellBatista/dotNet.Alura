using System.ComponentModel.DataAnnotations;

namespace _04_04_XX_Autorizacao_APP_Web.Web.Requests;
public record ArtistaRequest([Required] string nome, [Required] string bio, string? fotoPerfil);