using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Filmes.App.Dados
{
    class AluraFilmesContexto : DbContext
    {
        public DbSet<Ator> Atores { get; set; }
        public DbSet<Filme> Filmes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AluraFilmes;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //não preciso mais disso, porque separei para uma classe de configuração
            //modelBuilder.Entity<Ator>()
            //.ToTable("actor");
            //modelBuilder.Entity<Ator>()
            //    .Property(a => a.Id)
            //    .HasColumnName("actor_id");

            //modelBuilder.Entity<Ator>()
            //    .Property(a => a.PrimeiroNome)
            //    .HasColumnName("first_name")
            //    .HasColumnType("varchar(45)")
            //    .IsRequired();

            //modelBuilder.Entity<Ator>()
            //    .Property(a => a.UltimoNome)
            //    .HasColumnName("last_name")
            //    .HasColumnType("varchar(45)")
            //    .IsRequired();

            //modelBuilder.Entity<Ator>()
            //    .Property<DateTime>("last_update")
            //    .HasColumnType("datetime")
            //    .HasDefaultValueSql("getdate()");

            //não preciso dos códigos de cima, porque já separei para uma classe especializada
            modelBuilder.ApplyConfiguration(new AtorConfiguration());

            //não preciso mais disso, porque separei para uma classe de configuração
            //modelBuilder.Entity<Filme>()
            //    .ToTable("film");

            //modelBuilder.Entity<Filme>()
            //    .Property(f => f.Id)
            //    .HasColumnName("film_id");

            //modelBuilder.Entity<Filme>()
            //    .Property(f => f.Titulo)
            //    .HasColumnName("title")
            //    .HasColumnType("varchar(255)")
            //    .IsRequired();

            //modelBuilder.Entity<Filme>()
            //    .Property(f => f.Descricao)
            //    .HasColumnName("description")
            //    .HasColumnType("text");

            //modelBuilder.Entity<Filme>()
            //    .Property(f => f.AnoLancamento)
            //    .HasColumnName("release_year")
            //    .HasColumnType("varchar(4)");

            //modelBuilder.Entity<Filme>()
            //    .Property(f => f.Duracao)
            //    .HasColumnName("length");

            //modelBuilder.Entity<Filme>()
            //    .Property<DateTime>("last_update")
            //    .HasColumnType("datetime")
            //    .HasDefaultValueSql("getdate()");

            //não preciso dos códigos de cima, porque já separei para uma classe especializada
            modelBuilder.ApplyConfiguration(new FilmeConfiguration());
        }
    }
}
