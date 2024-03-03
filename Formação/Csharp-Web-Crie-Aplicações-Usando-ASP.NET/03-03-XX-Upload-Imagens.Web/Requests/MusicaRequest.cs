using System.ComponentModel.DataAnnotations;

namespace _03_03_XX_Upload_Imagens.Web.Requests;

public record MusicaRequest([Required] string nome, [Required] int ArtistaId, int anoLancamento, ICollection<GeneroRequest> Generos = null);