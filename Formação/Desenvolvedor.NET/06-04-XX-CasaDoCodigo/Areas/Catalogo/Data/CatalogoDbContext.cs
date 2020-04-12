using _06_04_XX_CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;

namespace _06_04_XX_CasaDoCodigo.Areas.Catalogo.Data
{
    public class CatalogoDbContext : DbContext
    {
        // chamando o construtor pai (base) e passando o parametro
        public CatalogoDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>(b =>
            {
                b.HasKey(t => t.Id);
            });

            modelBuilder.Entity<Produto>(b =>
            {
                b.HasKey(t => t.Id);
            });
        }
    }
}
