﻿using _03_XX_Relacionamentos.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _03_XX_Relacionamentos.Dados.Mapeamentos;

internal class ClienteTypeConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> entity)
    {
        entity.ToTable("TB_Clientes");

        entity.Property(e => e.Id).HasColumnName("Id_Cliente");
    }
}