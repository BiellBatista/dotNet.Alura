﻿using System.Net;
using System.Net.Http;

namespace _05_01_XX_Extraindo_Metodos.Http
{
    public class HttpResponse : IHttpResponse
    {
        private readonly HttpResponseMessage httpResponseMessage;
        internal HttpResponse(HttpResponseMessage httpResponseMessage)
        {
            this.httpResponseMessage = httpResponseMessage;
        }

        public bool Success => httpResponseMessage.IsSuccessStatusCode;
        public HttpStatusCode StatusCode => this.httpResponseMessage.StatusCode;
        public HttpContent Content => httpResponseMessage.Content;
    }
}
