using System.ComponentModel.DataAnnotations;

namespace _02_05_XX_DevOps.API.Requests;
public record ArtistaRequest([Required] string nome, [Required] string bio);