using _02_04_Aprovacao_proposta.Clientes.Cadastro;
using _02_04_Aprovacao_proposta.Engenharia.Conteineres;
using _02_04_Aprovacao_proposta.Vendas.Locacoes;
using _02_04_Aprovacao_proposta.Vendas.Propostas;
using Microsoft.EntityFrameworkCore;

namespace _02_04_Aprovacao_proposta.API.Data;

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