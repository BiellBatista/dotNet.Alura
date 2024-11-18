﻿using _01_XX_Melhorando_consultas.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01_XX_Melhorando_consultas.Dados.Mapeamentos;

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
            l => l.HasOne<Especialidade>(e => e.Especialidade).WithMany(e => e.ProfissionaisEspecialidade).HasForeignKey(e => e.EspecialidadeId),
            r => r.HasOne<Profissional>(e => e.Profissional).WithMany(e => e.ProfissionaisEspecialidade).HasForeignKey(e => e.ProfissionalId)
            );
    }
}