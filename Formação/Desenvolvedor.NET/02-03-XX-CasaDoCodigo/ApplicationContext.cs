using _02_03_XX_CasaDoCodigo.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_03_XX_CasaDoCodigo
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
        }
    }
}
