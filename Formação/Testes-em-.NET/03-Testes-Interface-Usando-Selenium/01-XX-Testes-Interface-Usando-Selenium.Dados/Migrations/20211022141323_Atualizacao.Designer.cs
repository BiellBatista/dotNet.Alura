﻿// <auto-generated />
using System;
using _01_XX_Testes_Interface_Usando_Selenium.Dados.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace _01_XX_Testes_Interface_Usando_Selenium.Dados.Migrations
{
    [DbContext(typeof(ByteBankContexto))]
    [Migration("20211022141323_Atualizacao")]
    partial class Atualizacao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("_01_XX_Testes_Interface_Usando_Selenium.Dominio.Entidades.Agencia", b =>
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

            modelBuilder.Entity("_01_XX_Testes_Interface_Usando_Selenium.Dominio.Entidades.Cliente", b =>
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

            modelBuilder.Entity("_01_XX_Testes_Interface_Usando_Selenium.Dominio.Entidades.ContaCorrente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AgenciaId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<Guid>("Identificador")
                        .HasColumnType("char(36)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<double>("Saldo")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("AgenciaId");

                    b.HasIndex("ClienteId");

                    b.ToTable("conta_corrente");
                });

            modelBuilder.Entity("_01_XX_Testes_Interface_Usando_Selenium.Dominio.Entidades.ContaCorrente", b =>
                {
                    b.HasOne("_01_XX_Testes_Interface_Usando_Selenium.Dominio.Entidades.Agencia", "Agencia")
                        .WithMany("Contas")
                        .HasForeignKey("AgenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_01_XX_Testes_Interface_Usando_Selenium.Dominio.Entidades.Cliente", "Cliente")
                        .WithMany("Contas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agencia");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("_01_XX_Testes_Interface_Usando_Selenium.Dominio.Entidades.Agencia", b =>
                {
                    b.Navigation("Contas");
                });

            modelBuilder.Entity("_01_XX_Testes_Interface_Usando_Selenium.Dominio.Entidades.Cliente", b =>
                {
                    b.Navigation("Contas");
                });
#pragma warning restore 612, 618
        }
    }
}
