using Alura.ListaLeitura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Alura.WebAPI.WebApp.HttpClients
{
    public class LivroApiClient
    {
        private readonly HttpClient _httpClient;

        public LivroApiClient(HttpClient httpClient)
        {
            //_httpClient = new HttpClient();
            //http://localhost:6000/api/livros/{id}
            //http://localhost:6000/api/listasLeituras/paraLer
            //http://localhost:6000/api/livros/{id}/capa
            //como o começo das URI é o mesmo, uso o BaseAddress para facilitar a montagem
            _httpClient = httpClient;
            //_httpClient.BaseAddress = new System.Uri("http://localhost:6000/api/");
        }

        public async Task<LivroApi> GetLivroAsync(int id)
        {
            //HttpClient httpClient = new HttpClient();
            ////http://localhost:6000/api/livros/{id}
            ////http://localhost:6000/api/listasLeituras/paraLer
            ////http://localhost:6000/api/livros/{id}/capa
            ////como o começo das URI é o mesmo, uso o BaseAddress para facilitar a montagem
            //httpClient.BaseAddress = new System.Uri("http://localhost:6000/api/");
            HttpResponseMessage resposta = await _httpClient.GetAsync($"livros/{id}"); //enviando um GET
            resposta.EnsureSuccessStatusCode(); //este método verifica se o status code da API é diferende da família 200. Se for, ele lança um throw

            return await resposta.Content.ReadAsAsync<LivroApi>(); //deseralizando o objeto vindo da API
        }

        public async Task<byte[]> GetCapaLivroAsync(int id)
        {
            HttpResponseMessage resposta = await _httpClient.GetAsync($"livros/{id}/capa");
            resposta.EnsureSuccessStatusCode();

           return await resposta.Content.ReadAsByteArrayAsync();
        }
    }
}
