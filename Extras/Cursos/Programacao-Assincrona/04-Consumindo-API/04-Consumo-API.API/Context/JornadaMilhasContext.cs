using _04_Consumo_API.API.Modelos;
using Microsoft.EntityFrameworkCore;

namespace _04_Consumo_API.API.Context;

public class JornadaMilhasContext : DbContext
{
    public JornadaMilhasContext(DbContextOptions<JornadaMilhasContext> options) : base(options)
    {
    }

    public DbSet<Voo> Voos { get; set; }
}