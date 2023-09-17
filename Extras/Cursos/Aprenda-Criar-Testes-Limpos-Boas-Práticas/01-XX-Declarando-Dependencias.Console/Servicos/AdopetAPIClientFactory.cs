﻿using System.Net.Http.Headers;

namespace _01_XX_Declarando_Dependencias.Console.Servicos
{
    internal class AdopetAPIClientFactory : IHttpClientFactory
    {
        private string url = "http://localhost:5057";

        public HttpClient CreateClient(string name)
        {
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri(url);
            return _client;
        }
    }
}