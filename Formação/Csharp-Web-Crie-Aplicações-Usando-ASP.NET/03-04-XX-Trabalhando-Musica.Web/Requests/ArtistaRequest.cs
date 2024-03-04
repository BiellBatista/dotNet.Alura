using System.ComponentModel.DataAnnotations;

namespace _03_04_XX_Trabalhando_Musica.Web.Requests;
public record ArtistaRequest([Required] string nome, [Required] string bio, string? fotoPerfil);