using _05_02_Nem_todo_contexto_ilha.API.Domain;
using _05_02_Nem_todo_contexto_ilha.Vendas.Locacoes;
using _05_02_Nem_todo_contexto_ilha.Vendas.Propostas;
using Microsoft.EntityFrameworkCore;

namespace _05_02_Nem_todo_contexto_ilha.API.Data;

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