using _05_03_Consultando_clientes_estado.Application.Repositories;
using _05_03_Consultando_clientes_estado.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace _05_03_Consultando_clientes_estado.WebApp.Data;

public class AppDbContext : DbContext, IClienteRepository
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }

    public async Task<Cliente> AddAsync(Cliente cliente)
    {
        await Clientes.AddAsync(cliente);
        await SaveChangesAsync();
        return cliente;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cliente>()
        .HasKey(c => c.Id);

        modelBuilder.Entity<Cliente>()
            .Property(c => c.Nome).IsRequired();
        modelBuilder.Entity<Cliente>()
            .OwnsOne(c => c.Email, cfg =>
            {
                cfg.Property(e => e.Value)
                    .HasColumnName("Email")
                    .IsRequired();
            });

        modelBuilder.Entity<Cliente>()
            .Property(c => c.CPF).IsRequired();
    }
}