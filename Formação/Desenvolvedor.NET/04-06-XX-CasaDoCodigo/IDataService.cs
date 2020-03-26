using System;
using System.Threading.Tasks;

namespace _04_06_XX_CasaDoCodigo
{
    public interface IDataService
    {
        Task InicializaDBAsync(IServiceProvider provider);
    }
}