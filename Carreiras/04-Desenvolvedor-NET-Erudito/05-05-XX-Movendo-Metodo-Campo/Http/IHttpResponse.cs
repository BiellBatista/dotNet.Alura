using System.Net;
using System.Net.Http;

namespace _05_05_XX_Movendo_Metodo_Campo.Http
{
    public interface IHttpResponse
    {
        HttpContent Content { get; }
        HttpStatusCode StatusCode { get; }
        bool Success { get; }
    }
}