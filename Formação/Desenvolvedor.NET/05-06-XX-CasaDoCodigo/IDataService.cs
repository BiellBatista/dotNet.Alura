using System;
using System.Threading.Tasks;

namespace _05_06_XX_CasaDoCodigo
{
    public interface IDataService
    {
        Task InicializaDBAsync(IServiceProvider provider);
    }
}