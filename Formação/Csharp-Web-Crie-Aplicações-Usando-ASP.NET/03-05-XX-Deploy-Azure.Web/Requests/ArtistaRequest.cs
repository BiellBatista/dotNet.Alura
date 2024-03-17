using System.ComponentModel.DataAnnotations;

namespace _03_05_XX_Deploy_Azure.Web.Requests;
public record ArtistaRequest([Required] string nome, [Required] string bio, string? fotoPerfil);