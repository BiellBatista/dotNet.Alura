using System;
using System.Threading.Tasks;

namespace _04_02_XX_CasaDoCodigo
{
    public interface IDataService
    {
        Task InicializaDBAsync(IServiceProvider provider);
    }
}