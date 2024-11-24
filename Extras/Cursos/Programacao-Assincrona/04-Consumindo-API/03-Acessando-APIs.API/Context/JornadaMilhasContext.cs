using _03_Acessando_APIs.API.Modelos;
using Microsoft.EntityFrameworkCore;

namespace _03_Acessando_APIs.API.Context;

public class JornadaMilhasContext : DbContext
{
    public JornadaMilhasContext(DbContextOptions<JornadaMilhasContext> options) : base(options)
    {
    }

    public DbSet<Voo> Voos { get; set; }
}