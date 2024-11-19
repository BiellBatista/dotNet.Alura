using _04_XX_Seguranca.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _04_XX_Seguranca.Dados.Mapeamentos;

internal class ProjetoEspecialidadeTypeConfiguration : IEntityTypeConfiguration<ProjetoEspecialidade>
{
    public void Configure(EntityTypeBuilder<ProjetoEspecialidade> entity)
    {
        entity.ToTable("TB_Especialidade_Projeto");
        entity.Property(e => e.ProjetoId).HasColumnName("Id_Projeto");
        entity.Property(e => e.EspecialidadeId).HasColumnName("Id_Especialidade");
    }
}