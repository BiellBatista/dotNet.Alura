﻿using _02_XX_Boas_Praticas_Testes.Console.Modelos;
using System.Net.Http.Json;

namespace _02_XX_Boas_Praticas_Testes.Console.Servicos
{
    public class HttpClientPet
    {
        private HttpClient client;

        public HttpClientPet(HttpClient client)
        {
            this.client = client;
        }

        public virtual Task CreatePetAsync(Pet pet)
        {
            return client.PostAsJsonAsync("pet/add", pet);
        }

        public async Task<IEnumerable<Pet>?> ListPetsAsync()
        {
            HttpResponseMessage response = await client.GetAsync("pet/list");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
        }
    }
}