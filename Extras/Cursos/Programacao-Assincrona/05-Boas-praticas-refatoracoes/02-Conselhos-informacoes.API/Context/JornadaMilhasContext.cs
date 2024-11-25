using _02_Conselhos_informacoes.API.Modelos;
using Microsoft.EntityFrameworkCore;

namespace _02_Conselhos_informacoes.API.Context;

public class JornadaMilhasContext : DbContext
{
    public JornadaMilhasContext(DbContextOptions<JornadaMilhasContext> options) : base(options)
    {
    }

    public DbSet<Voo> Voos { get; set; }
}