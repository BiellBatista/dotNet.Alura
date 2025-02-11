﻿// <auto-generated />
using System;
using _01_XX_Integrando_Aplicacao_Banco_Dados.Dados.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Alura.ByteBank.Dados.Migrations
{
    [DbContext(typeof(ByteBankContexto))]
    partial class ByteBankContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Alura.ByteBank.Dominio.Entidades.Agencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Endereco")
                        .HasColumnType("longtext");

                    b.Property<Guid>("Identificador")
                        .HasColumnType("char(36)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("agencia");
                });

            modelBuilder.Entity("Alura.ByteBank.Dominio.Entidades.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("Identificador")
                        .HasColumnType("char(36)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Profissao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("Alura.ByteBank.Dominio.Entidades.ContaCorrente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AgenciaId")
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<Guid>("Identificador")
                        .HasColumnType("char(36)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<Guid>("PixConta")
                        .HasColumnType("char(36)");

                    b.Property<double>("Saldo")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("AgenciaId");

                    b.HasIndex("ClienteId");

                    b.ToTable("conta_corrente");
                });

            modelBuilder.Entity("Alura.ByteBank.Dominio.Entidades.ContaCorrente", b =>
                {
                    b.HasOne("Alura.ByteBank.Dominio.Entidades.Agencia", "Agencia")
                        .WithMany("Contas")
                        .HasForeignKey("AgenciaId");

                    b.HasOne("Alura.ByteBank.Dominio.Entidades.Cliente", "Cliente")
                        .WithMany("Contas")
                        .HasForeignKey("ClienteId");

                    b.Navigation("Agencia");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Alura.ByteBank.Dominio.Entidades.Agencia", b =>
                {
                    b.Navigation("Contas");
                });

            modelBuilder.Entity("Alura.ByteBank.Dominio.Entidades.Cliente", b =>
                {
                    b.Navigation("Contas");
                });
#pragma warning restore 612, 618
        }
    }
}
