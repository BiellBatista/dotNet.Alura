using System.ComponentModel.DataAnnotations;

namespace _03_04_XX_Trabalhando_Musica.API.Requests;

public record MusicaRequest([Required] string nome, [Required] int ArtistaId, int anoLancamento, ICollection<GeneroRequest> Generos = null);