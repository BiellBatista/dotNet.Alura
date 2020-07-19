using System.Net.Http;
using System.Threading.Tasks;

namespace _05_03_XX_Quebrando_Variaveis_Preservando_Parametros.Http
{
    public interface IHttpResponseMessageClient
    {
        Task<HttpResponseMessage> GetHttpResponseMessage(string url);
        HttpResponseMessage GetHttpResponseMessageAsync(string url);
    }
}