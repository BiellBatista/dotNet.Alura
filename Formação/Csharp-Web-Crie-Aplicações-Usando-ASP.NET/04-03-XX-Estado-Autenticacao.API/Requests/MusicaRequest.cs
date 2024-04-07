using System.ComponentModel.DataAnnotations;

namespace _04_03_XX_Estado_Autenticacao.API.Requests;

public record MusicaRequest([Required] string nome, [Required] int ArtistaId, int anoLancamento, ICollection<GeneroRequest> Generos = null);