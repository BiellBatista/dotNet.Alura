﻿using _01_XX_Explorando_procedure.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01_XX_Explorando_procedure.Dados.Mapeamentos;

internal class ContratoTypeConfiguration : IEntityTypeConfiguration<Contrato>
{
    public void Configure(EntityTypeBuilder<Contrato> entity)
    {
        entity.ToTable("TB_Contratos");
        entity.Property(e => e.Id).HasColumnName("Id_Contrato");
        entity.Property(e => e.ServicoId).HasColumnName("ID_Servico");
        entity.Property(e => e.ProfissionalId).HasColumnName("ID_Profissional");
        entity.OwnsOne(e => e.Vigencia, vigencia =>
        {
            vigencia.Property(v => v.DataInicio).HasColumnName("Data_Inicio");
            vigencia.Property(v => v.DataEncerramento).HasColumnName("Data_Encerramento");
        });

        entity
            .HasOne(e => e.Servico)
            .WithOne(e => e.Contrato)
            .HasForeignKey<Contrato>(e => e.Id);

        entity
            .HasOne(e => e.Profissional)
            .WithMany(e => e.Contratos)
            .HasForeignKey(e => e.ProfissionalId);
    }
}