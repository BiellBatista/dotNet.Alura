using System.ComponentModel.DataAnnotations;

namespace _02_04_XX_Relacionando_Genero.API.Requests;
public record ArtistaRequest([Required] string nome, [Required] string bio);