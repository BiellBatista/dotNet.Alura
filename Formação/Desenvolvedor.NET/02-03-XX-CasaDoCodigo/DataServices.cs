using Microsoft.EntityFrameworkCore;

namespace _02_03_XX_CasaDoCodigo
{
    class DataServices : IDataServices
    {
        private readonly ApplicationContext contexto;

        public DataServices(ApplicationContext contexto)
        {
            this.contexto = contexto;
        }

        public void InicializaDB()
        {
            contexto.Database.Migrate();
        }
    }
}
