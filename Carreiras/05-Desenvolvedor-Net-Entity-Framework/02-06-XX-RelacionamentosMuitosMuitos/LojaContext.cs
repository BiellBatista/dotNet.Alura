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

        public LojaContext()
        { }

        public LojaContext(DbContextOptions<LojaContext> options) : base(options)
        { }

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