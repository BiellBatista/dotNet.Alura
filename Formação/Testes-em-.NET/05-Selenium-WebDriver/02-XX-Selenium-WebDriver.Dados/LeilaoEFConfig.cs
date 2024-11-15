﻿using _02_XX_Selenium_WebDriver.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace _02_XX_Selenium_WebDriver.Dados
{
    internal class LeilaoEFConfig : IEntityTypeConfiguration<Leilao>
    {
        public void Configure(EntityTypeBuilder<Leilao> builder)
        {
            builder.HasOne<Lance>(l => l.Ganhador);
            builder.Property<EstadoLeilao>(l => l.Estado)
                .HasConversion(e => e.ToString(), e => Enum.Parse<EstadoLeilao>(e));
        }
    }
}