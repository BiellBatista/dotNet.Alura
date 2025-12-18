using _03_02_Nova_forma_registrar_clientes.WebApp.Models;

namespace _03_02_Nova_forma_registrar_clientes.WebApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }

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