using _02_02_XX_Boas_Praticas_Testes.Console.Util;

namespace _02_02_XX_Boas_Praticas_Testes.Console.Comandos
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

        public Task ExecutarAsync(string[] args)
        {
            ExibeConteudoArquivo(caminhoDoArquivoASerExibido: args[1]);
            return Task.CompletedTask;
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