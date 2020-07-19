using System;
using System.Net;

namespace _05_03_XX_Quebrando_Variaveis_Preservando_Parametros.Http.Exceptions
{
    public class HttpRequestFailException : Exception
    {
        private readonly HttpStatusCode httpStatusCode;
        public HttpRequestFailException(HttpStatusCode httpStatusCode)
        {
            this.httpStatusCode = httpStatusCode;
        }

        public HttpStatusCode StatusCode => httpStatusCode;
    }
}
