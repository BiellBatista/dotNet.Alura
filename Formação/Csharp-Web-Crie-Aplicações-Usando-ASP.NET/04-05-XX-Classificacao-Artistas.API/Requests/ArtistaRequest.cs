using System.ComponentModel.DataAnnotations;

namespace _04_05_XX_Classificacao_Artistas.API.Requests;
public record ArtistaRequest([Required] string nome, [Required] string bio, string? fotoPerfil);