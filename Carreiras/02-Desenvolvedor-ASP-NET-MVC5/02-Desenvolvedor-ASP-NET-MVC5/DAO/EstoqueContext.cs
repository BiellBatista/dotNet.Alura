using _02_Desenvolvedor_ASP_NET_MVC5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _02_Desenvolvedor_ASP_NET_MVC5.DAO
{
    public class EstoqueContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<CategoriaDoProduto> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}