using System.ComponentModel.DataAnnotations;

namespace _03_02_XX_CRUD_Artista.Web.Requests;

public record MusicaRequest([Required] string nome, [Required] int ArtistaId, int anoLancamento, ICollection<GeneroRequest> Generos = null);

