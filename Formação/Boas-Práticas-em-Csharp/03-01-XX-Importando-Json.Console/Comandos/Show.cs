﻿using _03_01_XX_Importando_Json.Console.Atributos;
using _03_01_XX_Importando_Json.Console.Results;
using _03_01_XX_Importando_Json.Console.Servicos.Abstracoes;
using FluentResults;

namespace _03_01_XX_Importando_Json.Console.Comandos
{
    [DocComando(instrucao: "show",
       documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
    public class Show : IComando
    {
        private readonly ILeitorDeArquivos leitor;

        public Show(ILeitorDeArquivos leitor)
        {
            this.leitor = leitor;
        }

        public Task<Result> ExecutarAsync()
        {
            try
            {
                return ExibeConteudoArquivo();
            }
            catch (Exception exception)
            {
                return Task.FromResult(Result.Fail(new Error("Exibição do arquivo falhou!").CausedBy(exception)));
            }
        }

        private Task<Result> ExibeConteudoArquivo()
        {
            var listaDepets = leitor.RealizaLeitura();
            return Task.FromResult(Result.Ok().WithSuccess(new SuccessWithPets(listaDepets, "Exibição do arquivo realizada com sucesso!")));
        }
    }
}