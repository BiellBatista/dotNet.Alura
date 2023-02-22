namespace _05_XX_Filmes.API.Models;

public class Sessao
{
    public int? FilmeId { get; set; }

    public virtual Filme Filme { get; set; }

    public int? CinemaId { get; set; }

    public virtual Cinema Cinema { get; set; }
}