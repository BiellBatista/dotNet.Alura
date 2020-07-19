using System.Net.Http;
using System.Threading.Tasks;

namespace _05_04_XX_Substituindo_Metodo.Http
{
    public interface IHttpResponseMessageClient
    {
        Task<HttpResponseMessage> GetHttpResponseMessage(string url);
        HttpResponseMessage GetHttpResponseMessageAsync(string url);
    }
}