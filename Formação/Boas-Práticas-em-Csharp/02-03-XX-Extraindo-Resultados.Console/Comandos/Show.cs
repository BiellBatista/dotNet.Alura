using _02_03_XX_Extraindo_Resultados.Console.Util;
using FluentResults;

namespace _02_03_XX_Extraindo_Resultados.Console.Comandos
{
    [DocComando(instrucao: "show",
       documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
    internal class Show : IComando
    {
        private readonly LeitorDeArquivo leitor;

        public Show(LeitorDeArquivo leitor)
        {
            this.leitor = leitor;
        }

        public Task<Result> ExecutarAsync(string[] args)
        {
            try
            {
                ExibeConteudoArquivo(caminhoDoArquivoASerExibido: args[1]);
                return Task.FromResult(Result.Ok());
            }
            catch (Exception exception)
            {
                return Task.FromResult(Result.Fail(new Error("Importação falhou!").CausedBy(exception)));
            }
        }

        private void ExibeConteudoArquivo(string caminhoDoArquivoASerExibido)
        {
            var listaDepets = leitor.RealizaLeitura();
            foreach (var pet in listaDepets)
            {
                System.Console.WriteLine(pet);
            }
        }
    }
}