﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _02_XX_Conhecendo_Identity.Data;

namespace _02_XX_Conhecendo_Identity.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class FilmeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("_02_XX_Conhecendo_Identity.Models.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<int>("GerenteId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.HasIndex("GerenteId");

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("_02_XX_Conhecendo_Identity.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasColumnType("text");

                    b.Property<string>("Logradouro")
                        .HasColumnType("text");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("_02_XX_Conhecendo_Identity.Models.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Diretor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Duracao")
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("_02_XX_Conhecendo_Identity.Models.Gerente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Gerentes");
                });

            modelBuilder.Entity("_02_XX_Conhecendo_Identity.Models.Sessao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CinemaId")
                        .HasColumnType("int");

                    b.Property<int>("FilmeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("HorarioDeEncerramento")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.HasIndex("FilmeId");

                    b.ToTable("Sessoes");
                });

            modelBuilder.Entity("_02_XX_Conhecendo_Identity.Models.Cinema", b =>
                {
                    b.HasOne("_02_XX_Conhecendo_Identity.Models.Endereco", "Endereco")
                        .WithOne("Cinema")
                        .HasForeignKey("_02_XX_Conhecendo_Identity.Models.Cinema", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_02_XX_Conhecendo_Identity.Models.Gerente", "Gerente")
                        .WithMany("Cinemas")
                        .HasForeignKey("GerenteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Gerente");
                });

            modelBuilder.Entity("_02_XX_Conhecendo_Identity.Models.Sessao", b =>
                {
                    b.HasOne("_02_XX_Conhecendo_Identity.Models.Cinema", "Cinema")
                        .WithMany("Sessoes")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_02_XX_Conhecendo_Identity.Models.Filme", "Filme")
                        .WithMany("Sessoes")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("_02_XX_Conhecendo_Identity.Models.Cinema", b =>
                {
                    b.Navigation("Sessoes");
                });

            modelBuilder.Entity("_02_XX_Conhecendo_Identity.Models.Endereco", b =>
                {
                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("_02_XX_Conhecendo_Identity.Models.Filme", b =>
                {
                    b.Navigation("Sessoes");
                });

            modelBuilder.Entity("_02_XX_Conhecendo_Identity.Models.Gerente", b =>
                {
                    b.Navigation("Cinemas");
                });
#pragma warning restore 612, 618
        }
    }
}
