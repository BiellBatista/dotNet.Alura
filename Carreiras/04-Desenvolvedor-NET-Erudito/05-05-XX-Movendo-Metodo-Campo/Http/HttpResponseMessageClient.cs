﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace _05_05_XX_Movendo_Metodo_Campo.Http
{
    public class HttpResponseMessageClient : IHttpResponseMessageClient
    {
        private readonly HttpClientHandler httpClientHandler;

        public HttpResponseMessageClient() : this(new HttpClientHandler()) { }
        public HttpResponseMessageClient(HttpClientHandler httpClientHandler)
        {
            this.httpClientHandler = httpClientHandler;
        }

        public HttpResponseMessage GetHttpResponseMessageAsync(string url)
        {
            using (var httpClient = new HttpClient(httpClientHandler))
            {
                return httpClient.GetAsync(new Uri(url)).Result;
            }
        }

        public Task<HttpResponseMessage> GetHttpResponseMessage(string url)
        {
            using (var httpClient = new HttpClient(httpClientHandler))
            {
                return httpClient.GetAsync(new Uri(url));
            }
        }
    }
}
