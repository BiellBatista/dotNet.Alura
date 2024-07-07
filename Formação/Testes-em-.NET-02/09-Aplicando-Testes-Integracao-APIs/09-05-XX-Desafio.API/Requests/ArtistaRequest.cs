using System.ComponentModel.DataAnnotations;

namespace _09_05_XX_Desafio.API.Requests;
public record ArtistaRequest([Required] string nome, [Required] string bio);