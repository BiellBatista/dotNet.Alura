using System.ComponentModel.DataAnnotations;

namespace _03_01_XX_Web_App_Blazor.Web.Requests;

public record MusicaRequest([Required] string nome, [Required] int ArtistaId, int anoLancamento, ICollection<GeneroRequest> Generos = null);