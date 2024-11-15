﻿using _02_03_XX_Extraindo_Resultados.Console.Util;
using FluentResults;
using System.Reflection;

namespace _02_03_XX_Extraindo_Resultados.Console.Comandos
{
    [DocComando(instrucao: "help",
     documentacao: "adopet help comando que exibe informações da ajuda. \n" +
        "adopet help <NOME_COMANDO> para acessar a ajuda de um comando específico.")]
    internal class Help : IComando
    {
        private Dictionary<string, DocComandoAttribute> docs;

        public Help()
        {
            docs = DocumentacaoDoSistema.ToDictionary(Assembly.GetExecutingAssembly());
        }

        public Task<Result> ExecutarAsync(string[] args)
        {
            try
            {
                ExibeDocumentacao(parametros: args);
                return Task.FromResult(Result.Ok());
            }
            catch (Exception exception)
            {
                return Task.FromResult(Result.Fail(new Error("Exibição da documentação falhou!").CausedBy(exception)));
            }
        }

        private void ExibeDocumentacao(string[] parametros)
        {
            // se não passou mais nenhum argumento mostra help de todos os comandos
            if (parametros.Length == 1)
            {
                System.Console.WriteLine($"Adopet (1.0) - Aplicativo de linha de comando (CLI).");
                System.Console.WriteLine($"Realiza a importação em lote de um arquivos de pets.");
                System.Console.WriteLine($"Comando possíveis: ");
                foreach (var doc in docs.Values)
                {
                    System.Console.WriteLine(doc.Documentacao);
                }
            }
            // exibe o help daquele comando específico
            else if (parametros.Length == 2)
            {
                string comandoASerExibido = parametros[1];
                if (docs.ContainsKey(comandoASerExibido))
                {
                    var comando = docs[comandoASerExibido];
                    System.Console.WriteLine(comando.Documentacao);
                }
            }
        }
    }
}