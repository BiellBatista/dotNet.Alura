using System.Net;
using System.Net.Http;

namespace _05_04_XX_Substituindo_Metodo.Http
{
    public interface IHttpResponse
    {
        HttpContent Content { get; }
        HttpStatusCode StatusCode { get; }
        bool Success { get; }
    }
}