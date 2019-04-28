using _02_04_XX_CasaDoCodigo.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_04_XX_CasaDoCodigo
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // este método registra uma classe no modelo, para saber qual classe será usada para gerar o banco de dados
            modelBuilder.Entity<Produto>().HasKey(t => t.Id); //o método HashKey() indica a propriedade que representará a chave primária

            modelBuilder.Entity<Pedido>().HasKey(t => t.Id); //o método HashKey() indica a propriedade que representará a chave primária
            //Relacionamento 1:N (um pedido tem muitos itens).RelacionametoDeVolta cada item terá pedido
            modelBuilder.Entity<Pedido>().HasMany(t => t.Itens).WithOne(t => t.Pedido);
            //Relacionamento 1:1 (um pedido tem um cadastro).RelacionamentoDeVolta cada cadastro terá pedido.ÉObrigatório
            modelBuilder.Entity<Pedido>().HasOne(t => t.Cadastro).WithOne(t => t.Pedido).HasForeignKey<Cadastro>(t => t.Id).IsRequired();

            modelBuilder.Entity<ItemPedido>().HasKey(t => t.Id); //o método HashKey() indica a propriedade que representará a chave primária
            //Relacionamento 1:1 (um itemPedido tem um pedido)
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.Pedido);
            //Relacionamento 1:1 (um itemPedido tem um produto)
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.Produto);

            modelBuilder.Entity<Cadastro>().HasKey(t => t.Id); //o método HashKey() indica a propriedade que representará a chave primária
            //Relacionamento 1:1 (um cadastro tem um pedido)
            modelBuilder.Entity<Cadastro>().HasOne(t => t.Pedido);
        }
    }
}
