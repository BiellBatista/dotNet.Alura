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
        }
    }
}
