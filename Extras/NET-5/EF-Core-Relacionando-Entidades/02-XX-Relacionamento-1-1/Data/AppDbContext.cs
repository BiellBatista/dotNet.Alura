using _02_XX_Relacionamento_1_1.Models;
using Microsoft.EntityFrameworkCore;

namespace _02_XX_Relacionamento_1_1.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Filme> Filmes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {
        }
    }
}