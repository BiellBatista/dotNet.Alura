using System.Net;
using System.Net.Http;

namespace _05_01_XX_Extraindo_Metodos.Http
{
    public interface IHttpResponse
    {
        HttpContent Content { get; }
        HttpStatusCode StatusCode { get; }
        bool Success { get; }
    }
}