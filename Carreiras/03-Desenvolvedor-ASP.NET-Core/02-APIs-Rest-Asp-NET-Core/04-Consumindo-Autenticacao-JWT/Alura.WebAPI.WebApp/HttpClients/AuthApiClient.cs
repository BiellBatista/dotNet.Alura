using Alura.ListaLeitura.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Alura.WebAPI.WebApp.HttpClients
{
    public class AuthApiClient
    {
        private readonly HttpClient _httpClient;

        public AuthApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //realizando o login e retornando o toekn
        public async Task<string> PostLoginAsync(LoginModel model)
        {
            var resposta = await _httpClient.PostAsJsonAsync("login", model); //serializando o modelo e enviado um post para a url login
            resposta.EnsureSuccessStatusCode(); //o código do retorno está na família 200
            return await resposta.Content.ReadAsStringAsync();
        }
    }
}
