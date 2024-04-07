using System.ComponentModel.DataAnnotations;

namespace _04_03_XX_Estado_Autenticacao.API.Requests;
public record ArtistaRequest([Required] string nome, [Required] string bio, string? fotoPerfil);