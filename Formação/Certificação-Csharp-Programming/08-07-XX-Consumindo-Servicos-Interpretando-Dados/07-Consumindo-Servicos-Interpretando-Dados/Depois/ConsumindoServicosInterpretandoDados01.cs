﻿using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace _08_07_XX_Consumindo_Servicos_Interpretando_Dados.Depois
{
    public class ConsumindoServicosInterpretandoDados01 : IAulaItem //Json
    {
        public void Executar()
        {
            //TAREFA:
            //CONSULTAR OS DADOS DO CEP 04101-300
            //NO SERVIÇO DA http://viacep.com.br
            //E EXIBIR SEUS DADOS
            string cep = "04101300";
            string url = $"http://viacep.com.br/ws/{cep}/json/";

            using (var cliente = new HttpClient())
            {
                var json = cliente.GetStringAsync(url).Result;
                var endereco = JsonConvert.DeserializeObject<Endereco>(json);

                Console.WriteLine(
                    $"Logradouro: {endereco.logradouro}" +
                    $"\nBairro: {endereco.bairro}" +
                    $"\nMunicípio: {endereco.localidade}" +
                    $"\nUF: {endereco.uf}" +
                    $"\nCEP: {endereco.cep}");
            }
        }

        private class Endereco
        {
            public string cep { get; set; }
            public string logradouro { get; set; }
            public string bairro { get; set; }
            public string localidade { get; set; }
            public string uf { get; set; }
        }
    }
}