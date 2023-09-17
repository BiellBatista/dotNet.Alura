﻿using _04_XX_Testes_Automatizados.Console.Servicos;
using _04_XX_Testes_Automatizados.Console.Util;
using _05_XX_Desafios.Console.Modelos;

namespace _05_XX_Desafios.Console.Comandos;

[DocComando(instrucao: "import", documentacao: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
internal class Import : IComando
{
    public async Task ExecutarAsync(string[] args)
    {
        await ImportacaoArquivoPetAsync(caminhoDoArquivoDeImportacao: args[1]);
    }

    private async Task ImportacaoArquivoPetAsync(string caminhoDoArquivoDeImportacao)
    {
        var leitor = new LeitorDeArquivo();
        List<Pet> listaDePet = leitor.RealizaLeitura(caminhoDoArquivoDeImportacao);

        foreach (var pet in listaDePet)
        {
            System.Console.WriteLine(pet);
            try
            {
                var httpCreatePet = new HttpClientPet();

                await httpCreatePet.CreatePetAsync(pet);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        System.Console.WriteLine("Importação concluída!");
    }
}