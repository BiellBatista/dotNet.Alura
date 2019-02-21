using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class LojaContext : DbContext
    {
        // falando para o Entity manipular a tabela Produtos que está representada pela classe produto
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public LojaContext()
        { }

        public LojaContext(DbContextOptions<LojaContext> options) : base(options)
        { }

        // este método é executado no evento de criação do modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // montando uma chave composta para a tabela de join
            modelBuilder
                .Entity<PromocaoProduto>()
                .HasKey(pp => new { pp.PromocaoId, pp.ProdutoId });
            // O nome desse conceito para o Entity é Shadow Property, ou seja, uma propriedade que está escondida, ficando apenas no banco de dados.

            // noemando a tabela para Enderecos
            modelBuilder
                .Entity<Endereco>()
                .ToTable("Enderecos");

            modelBuilder
                .Entity<Endereco>()
                .Property<int>("ClienteId");

            modelBuilder
                .Entity<Endereco>()
                .HasKey("ClienteId");


            base.OnModelCreating(modelBuilder);
        }

        // falando qual o banco de dados que sera usado
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // verificando se o providre está configurado
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = LojaDB; Trusted_Connection = true;");
            }
        }
    }
}