using _09_Async_Aplicacoes_Web.API.Modelos;
using Microsoft.EntityFrameworkCore;

namespace _09_Async_Aplicacoes_Web.API.Context;

public class JornadaMilhasContext : DbContext
{
    public JornadaMilhasContext(DbContextOptions<JornadaMilhasContext> options) : base(options)
    {
    }

    public DbSet<Voo> Voos { get; set; }
}