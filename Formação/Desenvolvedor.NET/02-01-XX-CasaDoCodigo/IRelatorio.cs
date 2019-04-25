using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace _02_01_XX_CasaDoCodigo
{
    public interface IRelatorio
    {
        Task Imprimir(HttpContext context);
    }
}