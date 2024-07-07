using System.ComponentModel.DataAnnotations;

namespace _09_05_XX_Desafio.API.Requests;

public record MusicaRequest([Required] string nome, [Required] int ArtistaId, int anoLancamento, ICollection<GeneroRequest> Generos = null);