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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Endereco>()
                .HasOne(endereco => endereco.Cinema) //o endereço tem um cinema
                .WithOne(cinema => cinema.Endereco) //um cinema possui um endereço
                .HasForeignKey<Cinema>(cinema => cinema.EnderecoId); //chave de referencia do endereço está no cinema e é o EnderecoId
        }
    }
}