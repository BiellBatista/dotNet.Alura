using _01_XX_Melhorando_consultas.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01_XX_Melhorando_consultas.Dados.Mapeamentos;

internal class ProjetoTypeConfiguration : IEntityTypeConfiguration<Projeto>
{
    public void Configure(EntityTypeBuilder<Projeto> entity)
    {
        entity.ToTable("TB_Projetos");

        entity.HasKey(e => e.Id).HasName("PK_Projeto");

        entity.Property(e => e.Id).HasColumnName("Id_Projeto");

        entity.Property(e => e.Descricao)
            .HasColumnType("nvarchar(200)")
            .HasColumnName("DS_Projeto");

        entity
            .Property(e => e.Status)
            .HasConversion(
            fromObj => fromObj.ToString(),
            fromDb => (StatusProjeto)Enum.Parse(typeof(StatusProjeto), fromDb));

        entity
            .HasOne(e => e.Cliente)
            .WithMany(c => c.Projetos)
            .HasForeignKey("ID_Cliente");

        entity
            .HasMany(e => e.Especialidades)
            .WithMany(e => e.Projetos)
            .UsingEntity<ProjetoEspecialidade>(
            l => l.HasOne<Especialidade>(e => e.Especialidade).WithMany(e => e.ProjetosEspecialidade).HasForeignKey(e => e.EspecialidadeId),
            r => r.HasOne<Projeto>(e => e.Projeto).WithMany(e => e.ProjetosEspecialidade).HasForeignKey(e => e.ProjetoId)
            );
    }
}