using _02_XX_Melhorando_Legibilidade.API.Dominio;
using Microsoft.EntityFrameworkCore;

namespace _02_XX_Melhorando_Legibilidade.API.Dados.Context;

public class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.LogTo(Console.WriteLine);
    }

    public DbSet<Cliente> Clientes { get; set; }

    public DbSet<Pet> Pets { get; set; }
}