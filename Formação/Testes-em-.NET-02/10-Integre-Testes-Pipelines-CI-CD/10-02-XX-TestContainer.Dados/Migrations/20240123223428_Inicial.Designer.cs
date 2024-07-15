﻿// <auto-generated />
using System;
using _10_02_XX_TestContainer.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JornadaMilhas.Dados.Migrations
{
    [DbContext(typeof(JornadaMilhasContext))]
    [Migration("20240123223428_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JornadaMilhas.Dominio.Entidades.OfertaViagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.Property<int>("RotaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RotaId");

                    b.ToTable("OfertasViagem");
                });

            modelBuilder.Entity("JornadaMilhas.Dominio.Entidades.Rota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rota");
                });

            modelBuilder.Entity("JornadaMilhas.Dominio.Entidades.OfertaViagem", b =>
                {
                    b.HasOne("JornadaMilhas.Dominio.Entidades.Rota", "Rota")
                        .WithMany()
                        .HasForeignKey("RotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("JornadaMilhas.Dominio.ValueObjects.Periodo", "Periodo", b1 =>
                        {
                            b1.Property<int>("OfertaViagemId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("DataFinal")
                                .HasColumnType("datetime2")
                                .HasColumnName("DataFinal");

                            b1.Property<DateTime>("DataInicial")
                                .HasColumnType("datetime2")
                                .HasColumnName("DataInicial");

                            b1.HasKey("OfertaViagemId");

                            b1.ToTable("OfertasViagem");

                            b1.WithOwner()
                                .HasForeignKey("OfertaViagemId");
                        });

                    b.Navigation("Periodo")
                        .IsRequired();

                    b.Navigation("Rota");
                });
#pragma warning restore 612, 618
        }
    }
}
