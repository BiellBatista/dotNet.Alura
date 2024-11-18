﻿using _04_XX_Padroes_praticas.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _04_XX_Padroes_praticas.Dados.Mapeamentos;
internal class ProfissionalTypeConfiguration : IEntityTypeConfiguration<Profissional>
{
    public void Configure(EntityTypeBuilder<Profissional> entity)
    {
        entity.ToTable("TB_Profissionais");

        entity.Property(e => e.Id).HasColumnName("Id_Profissional");

        entity
            .HasMany(e => e.Especialidades)
            .WithMany(e => e.Profissionais)
            .UsingEntity<ProfissionalEspecialidade>(
            l => l.HasOne(e => e.Especialidade).WithMany(e => e.ProfissionaisEspecialidade).HasForeignKey(e => e.EspecialidadeId),
            r => r.HasOne(e => e.Profissional).WithMany(e => e.ProfissionaisEspecialidade).HasForeignKey(e => e.ProfissionalId)
            );
    }
}