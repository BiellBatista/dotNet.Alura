using _05_05_Camada_anticorrupcao.Clientes.Cadastro;
using _05_05_Camada_anticorrupcao.Engenharia.Conteineres;
using _05_05_Camada_anticorrupcao.Vendas.Locacoes;
using _05_05_Camada_anticorrupcao.Vendas.Propostas;
using Microsoft.EntityFrameworkCore;

namespace _05_05_Camada_anticorrupcao.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<PedidoLocacao> Pedidos { get; set; }
    public DbSet<Proposta> Propostas { get; set; }
    public DbSet<Locacao> Locacoes { get; set; }
    public DbSet<Conteiner> Conteineres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}