using _05_Trabalhando_consultas_Entity.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace _05_Trabalhando_consultas_Entity.Dados;

internal class SerenattoContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Pagamento> Pagamentos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<ItemPedido> ItensPedido { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    private static string connectionString = string.Empty;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
    }
}