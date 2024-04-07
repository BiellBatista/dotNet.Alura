using System.ComponentModel.DataAnnotations;

namespace _04_03_XX_Estado_Autenticacao.Web.Requests;
public record ArtistaRequest([Required] string nome, [Required] string bio, string? fotoPerfil);