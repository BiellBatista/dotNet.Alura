using System.ComponentModel.DataAnnotations;

namespace _04_02_XX_Autenticacao_APP_Web.API.Requests;

public record MusicaRequest([Required] string nome, [Required] int ArtistaId, int anoLancamento, ICollection<GeneroRequest> Generos = null);