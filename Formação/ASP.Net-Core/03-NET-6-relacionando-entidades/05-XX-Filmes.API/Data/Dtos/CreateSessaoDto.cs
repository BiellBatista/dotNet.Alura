using System.ComponentModel.DataAnnotations;

namespace _05_XX_Filmes.API.Data.Dtos;

public class CreateSessaoDto
{
    [Required]
    public int FilmeId { get; set; }
}