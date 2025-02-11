﻿using _03_XX_Topicos_Transacoes.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _03_XX_Topicos_Transacoes.Dados.Mapeamentos;

internal class ServicoTypeConfiguration : IEntityTypeConfiguration<Servico>
{
    public void Configure(EntityTypeBuilder<Servico> entity)
    {
        entity.ToTable("TB_Servicos");

        entity.Property(e => e.Id).HasColumnName("ID_Servico");
        entity.Property(e => e.Descricao).HasColumnName("DS_Projeto");
        entity.Property(e => e.ProjetoId).HasColumnName("ID_Projeto");

        entity
            .Property(e => e.Status)
            .HasConversion(
                fromObj => fromObj.ToString(),
                fromDb => (StatusServico)Enum.Parse(typeof(StatusServico), fromDb)
            );

        entity
            .HasOne(e => e.Contrato)
            .WithOne(e => e.Servico);

        entity
            .HasOne(e => e.Projeto)
            .WithMany(e => e.Servicos)
            .HasForeignKey(e => e.ProjetoId);
    }
}