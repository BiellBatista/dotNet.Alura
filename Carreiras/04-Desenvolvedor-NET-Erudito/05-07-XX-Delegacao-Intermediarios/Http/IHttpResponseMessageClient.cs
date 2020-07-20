using System.Net.Http;
using System.Threading.Tasks;

namespace _05_07_XX_Delegacao_Intermediarios.Http
{
    public interface IHttpResponseMessageClient
    {
        Task<HttpResponseMessage> GetHttpResponseMessage(string url);
        HttpResponseMessage GetHttpResponseMessageAsync(string url);
    }
}