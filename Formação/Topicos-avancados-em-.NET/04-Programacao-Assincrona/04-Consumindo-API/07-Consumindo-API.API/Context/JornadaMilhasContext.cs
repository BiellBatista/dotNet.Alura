using _07_Consumindo_API.API.Modelos;
using Microsoft.EntityFrameworkCore;

namespace _07_Consumindo_API.API.Context;

public class JornadaMilhasContext : DbContext
{
    public JornadaMilhasContext(DbContextOptions<JornadaMilhasContext> options) : base(options)
    {
    }

    public DbSet<Voo> Voos { get; set; }
}