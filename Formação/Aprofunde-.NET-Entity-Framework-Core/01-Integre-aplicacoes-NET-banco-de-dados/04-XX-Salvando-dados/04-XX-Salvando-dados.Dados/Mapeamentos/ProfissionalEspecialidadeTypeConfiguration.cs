﻿using _04_XX_Salvando_dados.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _04_XX_Salvando_dados.Dados.Mapeamentos;

internal class ProfissionalEspecialidadeTypeConfiguration : IEntityTypeConfiguration<ProfissionalEspecialidade>
{
    public void Configure(EntityTypeBuilder<ProfissionalEspecialidade> entity)
    {
        entity.ToTable("TB_Especialidade_Profissional");
        entity.Property(e => e.ProfissionalId).HasColumnName("Id_Profissional");
        entity.Property(e => e.EspecialidadeId).HasColumnName("Id_Especialidade");
    }
}