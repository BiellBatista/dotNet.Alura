using _07_Simulando_cancelamento.API.Modelos;
using Microsoft.EntityFrameworkCore;

namespace _07_Simulando_cancelamento.API.Context;

public class JornadaMilhasContext : DbContext
{
    public JornadaMilhasContext(DbContextOptions<JornadaMilhasContext> options) : base(options)
    {
    }

    public DbSet<Voo> Voos { get; set; }
}