using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.Filmes.App.Dados
{
    public class FilmeAtorConfiguration : IEntityTypeConfiguration<FilmeAtor>
    {
        public void Configure(EntityTypeBuilder<FilmeAtor> builder)
        {
            builder.ToTable("film_actor");

            //shadow properties é o nome do conceito de coluna que existe no relacional, mas não no orientação a objeto
            builder.Property<int>("film_id");
            builder.Property<int>("actor_id");
            builder.Property<DateTime>("last_update")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            builder.HasKey("film_id", "actor_id"); //falando que a entidade FilmeAtor possui chave primaria. Como tem dois argumentos, a chave é composto
            //para configurar uma chave estrangeira, é preciso determinar os dois lados do relacionamento
            //configurando a chave estrangeira do filme
            builder
                .HasOne(fa => fa.Filme) //um fileAtor tem um filme
                .WithMany(f => f.Atores) //falando que um filme possui vários atores. Ou seja, um filme tem vários autores
                .HasForeignKey("film_id"); //configurando a chave estrangeira na classe filmeAtor

            //configurando a chave estrangeira do ator
            builder
                .HasOne(fa => fa.Ator)
                .WithMany(a => a.Filmografia)
                .HasForeignKey("actor_id");
        }
    }
}
