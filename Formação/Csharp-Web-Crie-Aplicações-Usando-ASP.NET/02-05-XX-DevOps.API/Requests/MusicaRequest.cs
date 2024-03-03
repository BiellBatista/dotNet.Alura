using System.ComponentModel.DataAnnotations;

namespace _02_05_XX_DevOps.API.Requests;

public record MusicaRequest([Required] string nome, [Required] int ArtistaId, int anoLancamento, ICollection<GeneroRequest> Generos = null);