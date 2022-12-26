﻿// <auto-generated />
using System;
using _05_XX_Selenium_WebDriver.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace _05_XX_Selenium_WebDriver.Dados.Migrations
{
    [DbContext(typeof(LeiloesContext))]
    [Migration("20190425180504_Favoritos")]
    partial class Favoritos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_05_XX_Selenium_WebDriver.Core.Favorito", b =>
                {
                    b.Property<int>("IdLeilao");

                    b.Property<int>("IdInteressada");

                    b.HasKey("IdLeilao", "IdInteressada");

                    b.HasIndex("IdInteressada");

                    b.ToTable("Favoritos");
                });

            modelBuilder.Entity("_05_XX_Selenium_WebDriver.Core.Interessada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Interessada");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Fulano de Tal"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Mariana Mary"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Sicrana Silva"
                        });
                });

            modelBuilder.Entity("_05_XX_Selenium_WebDriver.Core.Lance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId");

                    b.Property<int>("LeilaoId");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("LeilaoId");

                    b.ToTable("Lance");
                });

            modelBuilder.Entity("_05_XX_Selenium_WebDriver.Core.Leilao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria")
                        .IsRequired();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<string>("Estado")
                        .IsRequired();

                    b.Property<int?>("GanhadorId");

                    b.Property<string>("Imagem")
                        .IsRequired();

                    b.Property<DateTime>("InicioPregao");

                    b.Property<DateTime>("TerminoPregao");

                    b.Property<string>("Titulo")
                        .IsRequired();

                    b.Property<double>("ValorInicial");

                    b.HasKey("Id");

                    b.HasIndex("GanhadorId");

                    b.ToTable("Leiloes");
                });

            modelBuilder.Entity("_05_XX_Selenium_WebDriver.Core.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int?>("InteressadaId");

                    b.Property<string>("Senha")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("InteressadaId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "fulano@example.org",
                            InteressadaId = 1,
                            Senha = "123"
                        },
                        new
                        {
                            Id = 2,
                            Email = "mariana@example.org",
                            InteressadaId = 2,
                            Senha = "456"
                        },
                        new
                        {
                            Id = 3,
                            Email = "admin@example.org",
                            Senha = "123"
                        });
                });

            modelBuilder.Entity("_05_XX_Selenium_WebDriver.Core.Favorito", b =>
                {
                    b.HasOne("_05_XX_Selenium_WebDriver.Core.Interessada", "Seguidor")
                        .WithMany("Favoritos")
                        .HasForeignKey("IdInteressada")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("_05_XX_Selenium_WebDriver.Core.Leilao", "LeilaoFavorito")
                        .WithMany("Seguidores")
                        .HasForeignKey("IdLeilao")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("_05_XX_Selenium_WebDriver.Core.Lance", b =>
                {
                    b.HasOne("_05_XX_Selenium_WebDriver.Core.Interessada", "Cliente")
                        .WithMany("Lances")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("_05_XX_Selenium_WebDriver.Core.Leilao", "Leilao")
                        .WithMany("Lances")
                        .HasForeignKey("LeilaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("_05_XX_Selenium_WebDriver.Core.Leilao", b =>
                {
                    b.HasOne("_05_XX_Selenium_WebDriver.Core.Lance", "Ganhador")
                        .WithMany()
                        .HasForeignKey("GanhadorId");
                });

            modelBuilder.Entity("_05_XX_Selenium_WebDriver.Core.Usuario", b =>
                {
                    b.HasOne("_05_XX_Selenium_WebDriver.Core.Interessada", "Interessada")
                        .WithMany()
                        .HasForeignKey("InteressadaId");
                });
#pragma warning restore 612, 618
        }
    }
}
