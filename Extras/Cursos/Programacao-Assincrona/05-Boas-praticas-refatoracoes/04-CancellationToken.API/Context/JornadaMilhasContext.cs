using _04_CancellationToken.API.Modelos;
using Microsoft.EntityFrameworkCore;

namespace _04_CancellationToken.API.Context;

public class JornadaMilhasContext : DbContext
{
    public JornadaMilhasContext(DbContextOptions<JornadaMilhasContext> options) : base(options)
    {
    }

    public DbSet<Voo> Voos { get; set; }
}