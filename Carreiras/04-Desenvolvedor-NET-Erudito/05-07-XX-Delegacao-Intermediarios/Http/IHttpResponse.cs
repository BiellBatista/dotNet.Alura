using System.Net;
using System.Net.Http;

namespace _05_07_XX_Delegacao_Intermediarios.Http
{
    public interface IHttpResponse
    {
        HttpContent Content { get; }
        HttpStatusCode StatusCode { get; }
        bool Success { get; }
    }
}