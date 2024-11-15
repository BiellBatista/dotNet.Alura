﻿using _03_06_XX_Enviando_Email.Console.Atributos;
using _03_06_XX_Enviando_Email.Console.Modelos;
using _03_06_XX_Enviando_Email.Console.Results;
using _03_06_XX_Enviando_Email.Console.Servicos.Abstracoes;
using FluentResults;

namespace _03_06_XX_Enviando_Email.Console.Comandos
{
    [DocComando(instrucao: "import",
        documentacao: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
    public class Import : IComando, IDepoisDaExecucao
    {
        private readonly IApiService<Pet> clientPet;

        private readonly ILeitorDeArquivos<Pet> leitor;

        public Import(IApiService<Pet> clientPet, ILeitorDeArquivos<Pet> leitor)
        {
            this.clientPet = clientPet;
            this.leitor = leitor;
        }

        public event Action<Result>? DepoisDaExecucao;

        public async Task<Result> ExecutarAsync()
        {
            return await ImportacaoArquivoPetAsync();
        }

        private async Task<Result> ImportacaoArquivoPetAsync()
        {
            try
            {
                var listaDePet = leitor.RealizaLeitura();
                foreach (var pet in listaDePet)
                {
                    await clientPet.CreateAsync(pet);
                }
                var resultado = Result.Ok().WithSuccess(new SuccessWithPets(listaDePet, "Importação Realizada com Sucesso!"));
                DepoisDaExecucao?.Invoke(resultado);
                return resultado;
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Importação falhou!").CausedBy(exception));
            }
        }
    }
}