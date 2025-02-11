﻿using System.Reflection;

namespace _01_05_XX_Desafios.Console.Comandos;

[DocComando(instrucao: "help", documentacao: "adopet help comando que exibe informações da ajuda.\nadopet help <NOME_COMANDO> para acessar a ajuda de um comando específico.")]
internal class Help : IComando
{
    private Dictionary<string, DocComando> docs;

    public Help()
    {
        docs = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetCustomAttributes<DocComando>().Any())
            .Select(t => t.GetCustomAttribute<DocComando>()!)
            .ToDictionary(d => d.Instrucao);
    }

    public Task ExecutarAsync(string[] args)
    {
        ExibeDocumentacao(parametros: args);

        return Task.CompletedTask;
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