using System.ComponentModel.DataAnnotations;

namespace _03_01_XX_Web_App_Blazor.Web.Requests;
public record ArtistaRequest([Required] string nome, [Required] string bio);