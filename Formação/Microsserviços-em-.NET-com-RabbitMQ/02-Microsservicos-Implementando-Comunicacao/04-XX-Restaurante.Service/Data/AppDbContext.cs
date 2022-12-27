using _04_XX_Restaurante.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace _04_XX_Restaurante.Service.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {
    }

    public DbSet<Restaurante> Restaurantes { get; set; }
}