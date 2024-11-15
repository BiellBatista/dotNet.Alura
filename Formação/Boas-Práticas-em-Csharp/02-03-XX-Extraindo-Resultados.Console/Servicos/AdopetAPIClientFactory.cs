﻿using System.Net.Http.Headers;

namespace _02_03_XX_Extraindo_Resultados.Console.Servicos
{
    public class AdopetAPIClientFactory : IHttpClientFactory
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