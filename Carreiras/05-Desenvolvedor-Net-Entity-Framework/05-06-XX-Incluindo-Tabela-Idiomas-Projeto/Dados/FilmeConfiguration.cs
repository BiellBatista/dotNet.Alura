using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.Filmes.App.Dados
{
    public class FilmeConfiguration : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder
                .ToTable("film");

            builder
                .Property(f => f.Id)
                .HasColumnName("film_id");

            builder
                .Property(f => f.Titulo)
                .HasColumnName("title")
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder
                .Property(f => f.Descricao)
                .HasColumnName("description")
                .HasColumnType("text");

            builder
                .Property(f => f.AnoLancamento)
                .HasColumnName("release_year")
                .HasColumnType("varchar(4)");

            builder
                .Property(f => f.Duracao)
                .HasColumnName("length");

            builder
                .Property<DateTime>("last_update")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            builder
                .Property<byte>("language_id");

            builder
                .Property<byte>("original_language_id");

            builder //um filme tem um idioma falado
                .HasOne(f => f.IdiomaFalado) //a propriedade filme possui um relacionamento 1:N com a coleção de Filmes na classe Idioma
                .WithMany(i => i.FilmesFalados) //um idioma tem muitos filmes falados
                .HasForeignKey("language_id");

            builder
                .HasOne(f => f.IdiomaOriginal) //um filme tem um idioma original
                .WithMany(i => i.FilmesOriginais) //um idioma original tem muitos filmes
                .HasForeignKey("original_language_id");
        }
    }
}
