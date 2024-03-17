using System.ComponentModel.DataAnnotations;

namespace _04_01_XX_Autenticacao_Autorizacao_API.Web.Requests;

public record MusicaRequest([Required] string nome, [Required] int ArtistaId, int anoLancamento, ICollection<GeneroRequest> Generos = null);