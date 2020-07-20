using System.Net;
using System.Net.Http;

namespace _05_08_XX_Introduzir_Metodo_Estrangeiro.Http
{
    public interface IHttpResponse
    {
        HttpContent Content { get; }
        HttpStatusCode StatusCode { get; }
        bool Success { get; }
    }
}