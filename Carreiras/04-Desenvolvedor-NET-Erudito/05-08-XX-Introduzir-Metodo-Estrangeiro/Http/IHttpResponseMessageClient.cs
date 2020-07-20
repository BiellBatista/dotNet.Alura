using System.Net.Http;
using System.Threading.Tasks;

namespace _05_08_XX_Introduzir_Metodo_Estrangeiro.Http
{
    public interface IHttpResponseMessageClient
    {
        Task<HttpResponseMessage> GetHttpResponseMessage(string url);
        HttpResponseMessage GetHttpResponseMessageAsync(string url);
    }
}