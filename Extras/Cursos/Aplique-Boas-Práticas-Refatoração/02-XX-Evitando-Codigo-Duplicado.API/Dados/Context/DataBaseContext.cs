using _02_XX_Evitando_Codigo_Duplicado.API.Dominio;
using Microsoft.EntityFrameworkCore;

namespace _02_XX_Evitando_Codigo_Duplicado.API.Dados.Context;

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