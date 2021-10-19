using _02_XX_Conhecendo_Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace _02_XX_Conhecendo_Identity.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }

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

            builder
                .Entity<Cinema>()
                .HasOne(cinema => cinema.Gerente)
                .WithMany(gerente => gerente.Cinemas)
                .HasForeignKey(cinema => cinema.GerenteId)
                .OnDelete(DeleteBehavior.Restrict); //removendo a deleção em cascata

            builder
                .Entity<Sessao>()
                .HasOne(sessao => sessao.Filme)
                .WithMany(filme => filme.Sessoes)
                .HasForeignKey(sessao => sessao.FilmeId);

            builder
                .Entity<Sessao>()
                .HasOne(sessao => sessao.Cinema)
                .WithMany(cinema => cinema.Sessoes)
                .HasForeignKey(sessao => sessao.CinemaId);
        }
    }
}