using System.Net;
using System.Net.Http;

namespace _05_06_XX_Extraindo_Incorporando_Classe.Http
{
    public interface IHttpResponse
    {
        HttpContent Content { get; }
        HttpStatusCode StatusCode { get; }
        bool Success { get; }
    }
}