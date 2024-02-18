using _01_02_XX_Bibliotecas_ORM.Modelos;
using Microsoft.EntityFrameworkCore;

namespace _01_02_XX_Bibliotecas_ORM.Banco;

internal class _01_02_XX_Bibliotecas_ORMContext : DbContext
{
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }

    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=_01_02_XX_Bibliotecas_ORM;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
}