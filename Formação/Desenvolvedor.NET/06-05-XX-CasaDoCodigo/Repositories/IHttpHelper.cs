using System.Threading.Tasks;
using _06_05_XX_CasaDoCodigo.Models;
using Microsoft.Extensions.Configuration;

namespace _06_05_XX_CasaDoCodigo
{
    public interface IHttpHelper
    {
        IConfiguration Configuration { get; }
        int? GetPedidoId();
        void SetPedidoId(int pedidoId);
        void ResetPedidoId();
    }
}