using _06_05_XX_CasaDoCodigo.Areas.Catalogo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace _06_05_XX_CasaDoCodigo.Areas.Catalogo.Data.Repositories
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected readonly IConfiguration configuration;
        protected readonly CatalogoDbContext contexto;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(IConfiguration configuration,
            CatalogoDbContext contexto)
        {
            this.configuration = configuration;
            this.contexto = contexto;
            dbSet = contexto.Set<T>();
        }
    }
}
