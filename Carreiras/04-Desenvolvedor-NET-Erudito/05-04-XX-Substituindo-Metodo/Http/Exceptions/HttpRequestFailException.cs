using System;
using System.Net;

namespace _05_04_XX_Substituindo_Metodo.Http.Exceptions
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
