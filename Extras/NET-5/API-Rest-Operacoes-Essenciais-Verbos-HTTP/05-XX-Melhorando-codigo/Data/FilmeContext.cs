using _05_XX_Melhorando_codigo.Models;
using Microsoft.EntityFrameworkCore;

namespace _05_XX_Melhorando_codigo.Data
{
    public class FilmeContext : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }

        public FilmeContext(DbContextOptions<FilmeContext> option) : base(option)
        {
        }
    }
}