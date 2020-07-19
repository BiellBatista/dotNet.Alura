using System.Net;
using System.Net.Http;

namespace _05_02_XX_Extraindo_Variaveis_Temporarias.Http
{
    public interface IHttpResponse
    {
        HttpContent Content { get; }
        HttpStatusCode StatusCode { get; }
        bool Success { get; }
    }
}