﻿using _05_02_XX_Extraindo_Variaveis_Temporarias.Http.Exceptions;
using System.Net.Http;
using System.Threading.Tasks;

namespace _05_02_XX_Extraindo_Variaveis_Temporarias.Http
{
    public class ViaCEPClient : IViaCEPClient
    {
        private const string VIACEP_URL = "https://viacep.com.br/ws/{0}/{1}/";

        private readonly IHttpResponseMessageClient httpResponseMessageClient;

        public ViaCEPClient()
        {
            this.httpResponseMessageClient = new HttpResponseMessageClient();
        }

        public ViaCEPClient(HttpClientHandler httpClientHandler)
        {
            this.httpResponseMessageClient = new HttpResponseMessageClient(httpClientHandler);
        }

        public async Task<string> GetEnderecoAsync(string cep, string outputType)
        {
            return await GetStringResponseAsync(string.Format(VIACEP_URL, cep, outputType));
        }

        public string GetEndereco(string cep, string outputType)
        {
            return GetStringResponse(string.Format(VIACEP_URL, cep, outputType));
        }

        private async Task<string> GetStringResponseAsync(string url)
        {
            using (var r = httpResponseMessageClient.GetHttpResponseMessageAsync(url))
            {
                if (r.IsSuccessStatusCode)
                {
                    return await r.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new HttpRequestFailException(r.StatusCode);
                }
            }
        }

        private string GetStringResponse(string url)
        {
            using (var r = httpResponseMessageClient.GetHttpResponseMessageAsync(url))
            {
                if (r.IsSuccessStatusCode)
                {
                    return r.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    throw new HttpRequestFailException(r.StatusCode);
                }
            }
        }
    }
}
