using System.ComponentModel.DataAnnotations;

namespace _03_XX_Filmes.API.Data.Dtos;

public class CreateSessaoDto
{
    [Required]
    public int FilmeId { get; set; }
}