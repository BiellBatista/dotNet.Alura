using _01_XX_Incrementando_Projeto.Models;
using Microsoft.EntityFrameworkCore;

namespace _01_XX_Incrementando_Projeto.Data
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