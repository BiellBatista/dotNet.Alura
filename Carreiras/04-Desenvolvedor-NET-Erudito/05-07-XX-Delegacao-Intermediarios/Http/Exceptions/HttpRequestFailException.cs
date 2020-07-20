using System;
using System.Net;

namespace _05_07_XX_Delegacao_Intermediarios.Http.Exceptions
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
