using _01_03_XX_Generics.Modelos;
using Microsoft.EntityFrameworkCore;

namespace _01_03_XX_Generics.Banco;

internal class ScreenSoundContext : DbContext
{
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }

    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSound;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
}