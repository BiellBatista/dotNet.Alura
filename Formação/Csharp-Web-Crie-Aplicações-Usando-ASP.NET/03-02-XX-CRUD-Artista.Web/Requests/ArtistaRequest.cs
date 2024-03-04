using System.ComponentModel.DataAnnotations;

namespace _03_02_XX_CRUD_Artista.Web.Requests;
public record ArtistaRequest([Required] string nome, [Required] string bio);