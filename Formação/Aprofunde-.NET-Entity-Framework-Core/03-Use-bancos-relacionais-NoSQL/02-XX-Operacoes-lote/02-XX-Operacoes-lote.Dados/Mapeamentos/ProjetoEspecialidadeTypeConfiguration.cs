using _02_XX_Operacoes_lote.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _02_XX_Operacoes_lote.Dados.Mapeamentos;

internal class ProjetoEspecialidadeTypeConfiguration : IEntityTypeConfiguration<ProjetoEspecialidade>
{
    public void Configure(EntityTypeBuilder<ProjetoEspecialidade> entity)
    {
        entity.ToTable("TB_Especialidade_Projeto");
        entity.Property(e => e.ProjetoId).HasColumnName("Id_Projeto");
        entity.Property(e => e.EspecialidadeId).HasColumnName("Id_Especialidade");
    }
}