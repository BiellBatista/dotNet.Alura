using System.ComponentModel.DataAnnotations;

namespace _02_04_XX_Relacionando_Genero.API.Requests;

public record MusicaRequest([Required] string nome, [Required] int ArtistaId, int anoLancamento, ICollection<GeneroRequest> Generos = null);