﻿using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace _01_01_XX_Melhorando_Legibilidade.Console;

internal class Import
{
    private HttpClient client;

    public Import()
    {
        client = ConfiguraHttpClient("http://localhost:5057");
    }

    public async Task ImportacaoArquivoPetAsync(string caminhoDoArquivoDeImportacao)
    {
        List<Pet> listaDePet = new List<Pet>();

        using (StreamReader sr = new StreamReader(caminhoDoArquivoDeImportacao))
        {
            System.Console.WriteLine("----- Dados importados -----");

            while (!sr.EndOfStream)
            {
                // separa linha usando ponto e vírgula
                string[]? propriedades = sr.ReadLine().Split(';');
                // cria objeto Pet a partir da separação
                Pet pet = new Pet(Guid.Parse(propriedades[0]), propriedades[1], int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro);

                System.Console.WriteLine(pet);

                listaDePet.Add(pet);
            }
        }
        foreach (var pet in listaDePet)
        {
            try
            {
                var resposta = await CreatePetAsync(pet);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        System.Console.WriteLine("Importação concluída!");
    }

    private Task<HttpResponseMessage> CreatePetAsync(Pet pet)
    {
        HttpResponseMessage? response = null;

        using (response = new HttpResponseMessage())
        {
            return client.PostAsJsonAsync("pet/add", pet);
        }
    }

    private HttpClient ConfiguraHttpClient(string url)
    {
        HttpClient _client = new HttpClient();

        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _client.BaseAddress = new Uri(url);

        return _client;
    }
}