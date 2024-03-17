using System.ComponentModel.DataAnnotations;

namespace _03_05_XX_Deploy_Azure.Web.Requests;

public record MusicaRequest([Required] string nome, [Required] int ArtistaId, int anoLancamento, ICollection<GeneroRequest> Generos = null);