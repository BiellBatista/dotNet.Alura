using System.Net.Http;
using System.Threading.Tasks;

namespace _05_01_XX_Extraindo_Metodos.Http
{
    public interface IHttpResponseMessageClient
    {
        Task<HttpResponseMessage> GetHttpResponseMessage(string url);
        HttpResponseMessage GetHttpResponseMessageAsync(string url);
    }
}