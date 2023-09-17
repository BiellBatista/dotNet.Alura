using _03_XX_Padroes_Projeto_Command.API.Dominio;
using Microsoft.EntityFrameworkCore;

namespace _03_XX_Padroes_Projeto_Command.API.Dados.Context;

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