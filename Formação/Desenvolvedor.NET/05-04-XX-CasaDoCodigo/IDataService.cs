using System;
using System.Threading.Tasks;

namespace _05_04_XX_CasaDoCodigo
{
    public interface IDataService
    {
        Task InicializaDBAsync(IServiceProvider provider);
    }
}