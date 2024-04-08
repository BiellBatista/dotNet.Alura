using System.ComponentModel.DataAnnotations;

namespace _04_05_XX_Classificacao_Artistas.Web.Requests;

public record MusicaRequest([Required] string nome, [Required] int ArtistaId, int anoLancamento, ICollection<GeneroRequest> Generos = null);