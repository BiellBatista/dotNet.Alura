using System.ComponentModel.DataAnnotations;

namespace _04_04_XX_Autorizacao_APP_Web.API.Requests;

public record MusicaRequest([Required] string nome, [Required] int ArtistaId, int anoLancamento, ICollection<GeneroRequest> Generos = null);