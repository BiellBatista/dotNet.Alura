using System.Net.Http;
using System.Threading.Tasks;

namespace _05_02_XX_Extraindo_Variaveis_Temporarias.Http
{
    public interface IHttpResponseMessageClient
    {
        Task<HttpResponseMessage> GetHttpResponseMessage(string url);
        HttpResponseMessage GetHttpResponseMessageAsync(string url);
    }
}