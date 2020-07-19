using System.Net.Http;
using System.Threading.Tasks;

namespace _05_05_XX_Movendo_Metodo_Campo.Http
{
    public interface IHttpResponseMessageClient
    {
        Task<HttpResponseMessage> GetHttpResponseMessage(string url);
        HttpResponseMessage GetHttpResponseMessageAsync(string url);
    }
}