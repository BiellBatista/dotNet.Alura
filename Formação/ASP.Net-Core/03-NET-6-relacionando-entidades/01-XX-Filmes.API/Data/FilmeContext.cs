using _01_XX_Filmes.API.Models;
using Microsoft.EntityFrameworkCore;

namespace _01_XX_Filmes.API.Data;

public class FilmeContext : DbContext
{
    public DbSet<Cinema> Cinemas { get; set; }

    public DbSet<Filme> Filmes { get; set; }

    public FilmeContext(DbContextOptions<FilmeContext> opts)
        : base(opts)
    {
    }
}