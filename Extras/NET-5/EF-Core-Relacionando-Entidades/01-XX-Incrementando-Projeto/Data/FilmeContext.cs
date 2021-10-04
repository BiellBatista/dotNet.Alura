using _01_XX_Incrementando_Projeto.Models;
using Microsoft.EntityFrameworkCore;

namespace _01_XX_Incrementando_Projeto.Data
{
    public class FilmeContext : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }

        public FilmeContext(DbContextOptions<FilmeContext> option) : base(option)
        {
        }
    }
}