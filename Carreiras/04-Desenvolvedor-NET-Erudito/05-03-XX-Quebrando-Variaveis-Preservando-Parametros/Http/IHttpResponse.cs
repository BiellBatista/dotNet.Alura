using System.Net;
using System.Net.Http;

namespace _05_03_XX_Quebrando_Variaveis_Preservando_Parametros.Http
{
    public interface IHttpResponse
    {
        HttpContent Content { get; }
        HttpStatusCode StatusCode { get; }
        bool Success { get; }
    }
}