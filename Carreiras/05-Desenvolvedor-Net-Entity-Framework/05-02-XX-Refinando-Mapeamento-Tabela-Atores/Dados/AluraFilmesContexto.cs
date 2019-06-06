using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;

namespace Alura.Filmes.App.Dados
{
    class AluraFilmesContexto : DbContext
    {
        public DbSet<Ator> Atores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AluraFilmes;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        //este método representa o evento de criação do modelo de mapeamento
        //configurando por aqui, chamo o código de Fluent API.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //falando que o contexto irá mapear a entidade Ator para a tabela "actor"
            modelBuilder.Entity<Ator>().ToTable("actor");

            modelBuilder.Entity<Ator>()
                .Property(a => a.Id) // pegando a propriedade Id
                .HasColumnName("actor_id"); //falando que a propriedade Id referencia a coluna actor_id

            modelBuilder.Entity<Ator>()
                .Property(a => a.PrimeiroNome) // pegando a propriedade PrimeiroNome
                .HasColumnName("first_name") //falando que a propriedade PrimeiroNome referencia a coluna first_name
                .HasColumnType("varchar(45)") //falando que a propriedade PrimeiroNome referencia uma coluna do tipo varchar64
                .IsRequired(); //falando que a prorpeidade PrimeiroNome referencia uma coluna não nula

            modelBuilder.Entity<Ator>()
                .Property(a => a.UltimoNome) // pegando a propriedade UltimoNome
                .HasColumnName("last_name") //falando que a propriedade UltimoNome referencia a coluna first_name
                .HasColumnType("varchar(45)") //falando que a propriedade UltimoNome referencia uma coluna do tipo varchar64
                .IsRequired(); //falando que a prorpeidade UltimoNome referencia uma coluna não nula
        }
    }
}
