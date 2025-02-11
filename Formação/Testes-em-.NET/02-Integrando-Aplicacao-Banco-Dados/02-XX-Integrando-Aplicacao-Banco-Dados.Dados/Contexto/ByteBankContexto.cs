﻿using _02_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace _02_XX_Integrando_Aplicacao_Banco_Dados.Dados.Contexto
{
    public class ByteBankContexto : DbContext
    {
        public DbSet<ContaCorrente> ContaCorrentes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Agencia> Agencias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string stringconexao = "server=localhost;DataBase=bytebankBD;Uid=root;Pwd=root";
            optionsBuilder.UseMySql(stringconexao, ServerVersion.AutoDetect(stringconexao));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.Identificador);
                entity.Property(e => e.Profissao).IsRequired();
                entity.Property(e => e.CPF).IsRequired();
            });

            modelBuilder.Entity<Agencia>(entity =>
            {
                entity.ToTable("agencia");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Numero).IsRequired();
                entity.Property(e => e.Endereco);
                entity.Property(e => e.Identificador);
                entity.Property(e => e.Nome).IsRequired();
            });

            modelBuilder.Entity<ContaCorrente>(entity =>
            {
                entity.ToTable("conta_corrente");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Numero).IsRequired();
                entity.Property(e => e.Identificador);
                entity.Property(e => e.PixConta);
                entity.Property(e => e.Saldo);
                entity.HasOne(d => d.Cliente).WithMany(p => p.Contas);
                entity.HasOne(d => d.Agencia).WithMany(p => p.Contas);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}