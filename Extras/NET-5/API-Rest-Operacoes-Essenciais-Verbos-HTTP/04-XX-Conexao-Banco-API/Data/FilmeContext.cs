using _04_XX_Conexao_Banco_API.Models;
using Microsoft.EntityFrameworkCore;

namespace _04_XX_Conexao_Banco_API.Data
{
    public class FilmeContext : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }

        public FilmeContext(DbContextOptions<FilmeContext> option) : base(option)
        {
        }
    }
}