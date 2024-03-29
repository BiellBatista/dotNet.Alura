﻿using _02_02_XX_Boas_Praticas_Testes.Console.Modelos;
using _02_02_XX_Boas_Praticas_Testes.Console.Servicos;
using _02_02_XX_Boas_Praticas_Testes.Console.Util;

namespace _02_02_XX_Boas_Praticas_Testes.Console.Comandos
{
    [DocComando(instrucao: "import",
        documentacao: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
    public class Import : IComando
    {
        private readonly HttpClientPet clientPet;

        private readonly LeitorDeArquivo leitor;

        public Import(HttpClientPet clientPet, LeitorDeArquivo leitor)
        {
            this.clientPet = clientPet;
            this.leitor = leitor;
        }

        public async Task ExecutarAsync(string[] args)
        {
            await ImportacaoArquivoPetAsync(caminhoDoArquivoDeImportacao: args[1]);
        }

        private async Task ImportacaoArquivoPetAsync(string caminhoDoArquivoDeImportacao)
        {
            List<Pet> listaDePet = leitor.RealizaLeitura();
            foreach (var pet in listaDePet)
            {
                System.Console.WriteLine(pet);
                try
                {
                    await clientPet.CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            System.Console.WriteLine("Importação concluída!");
        }
    }
}