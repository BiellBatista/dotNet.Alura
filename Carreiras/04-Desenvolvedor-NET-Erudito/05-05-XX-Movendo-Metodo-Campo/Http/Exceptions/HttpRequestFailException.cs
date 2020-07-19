using System;
using System.Net;

namespace _05_05_XX_Movendo_Metodo_Campo.Http.Exceptions
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
