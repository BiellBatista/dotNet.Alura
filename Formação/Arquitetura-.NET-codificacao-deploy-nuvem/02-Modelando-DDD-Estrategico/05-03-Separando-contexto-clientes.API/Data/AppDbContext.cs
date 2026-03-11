using _05_03_Separando_contexto_clientes.API.Domain;
using _05_03_Separando_contexto_clientes.Clientes.Cadastro;
using _05_03_Separando_contexto_clientes.Vendas.Locacoes;
using _05_03_Separando_contexto_clientes.Vendas.Propostas;
using Microsoft.EntityFrameworkCore;

namespace _05_03_Separando_contexto_clientes.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<PedidoLocacao> Solicitacoes { get; set; }
    public DbSet<Proposta> Propostas { get; set; }
    public DbSet<Locacao> Locacoes { get; set; }
    public DbSet<Conteiner> Conteineres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}