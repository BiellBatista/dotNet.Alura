using System.ComponentModel.DataAnnotations;

namespace _02_XX_Filmes.API.Data.Dtos;

public class UpdateCinemaDto
{
    [Required(ErrorMessage = "O campo de nome é obrigatório.")]
    public string Nome { get; set; }
}