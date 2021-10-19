﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _04_XX_Tornando_Cadastro_Sofisticado.Data;

namespace _04_XX_Tornando_Cadastro_Sofisticado.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211017225816_AdicionandoRelacionamentoEntreCinemaEFilme")]
    partial class AdicionandoRelacionamentoEntreCinemaEFilme
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("CinemaFilme", b =>
                {
                    b.Property<int>("CinemasId")
                        .HasColumnType("int");

                    b.Property<int>("FilmesId")
                        .HasColumnType("int");

                    b.HasKey("CinemasId", "FilmesId");

                    b.HasIndex("FilmesId");

                    b.ToTable("CinemaFilme");
                });

            modelBuilder.Entity("_04_XX_Tornando_Cadastro_Sofisticado.Models.Cinema", b =>
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

            modelBuilder.Entity("_04_XX_Tornando_Cadastro_Sofisticado.Models.Endereco", b =>
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

            modelBuilder.Entity("_04_XX_Tornando_Cadastro_Sofisticado.Models.Filme", b =>
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

            modelBuilder.Entity("_04_XX_Tornando_Cadastro_Sofisticado.Models.Gerente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Gerentes");
                });

            modelBuilder.Entity("CinemaFilme", b =>
                {
                    b.HasOne("_04_XX_Tornando_Cadastro_Sofisticado.Models.Cinema", null)
                        .WithMany()
                        .HasForeignKey("CinemasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_04_XX_Tornando_Cadastro_Sofisticado.Models.Filme", null)
                        .WithMany()
                        .HasForeignKey("FilmesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("_04_XX_Tornando_Cadastro_Sofisticado.Models.Cinema", b =>
                {
                    b.HasOne("_04_XX_Tornando_Cadastro_Sofisticado.Models.Endereco", "Endereco")
                        .WithOne("Cinema")
                        .HasForeignKey("_04_XX_Tornando_Cadastro_Sofisticado.Models.Cinema", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_04_XX_Tornando_Cadastro_Sofisticado.Models.Gerente", "Gerente")
                        .WithMany("Cinemas")
                        .HasForeignKey("GerenteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Gerente");
                });

            modelBuilder.Entity("_04_XX_Tornando_Cadastro_Sofisticado.Models.Endereco", b =>
                {
                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("_04_XX_Tornando_Cadastro_Sofisticado.Models.Gerente", b =>
                {
                    b.Navigation("Cinemas");
                });
#pragma warning restore 612, 618
        }
    }
}
