using _01_05_XX_Desafios.Console.Util;

namespace _01_05_XX_Desafios.Console.Comandos;

[DocComando(instrucao: "show", documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
internal class Show : IComando
{
    public Task ExecutarAsync(string[] args)
    {
        ExibeConteudoArquivo(caminhoDoArquivoASerExibido: args[1]);

        return Task.CompletedTask;
    }

    private void ExibeConteudoArquivo(string caminhoDoArquivoASerExibido)
    {
        LeitorDeArquivo leitor = new LeitorDeArquivo();

        var listaDepets = leitor.RealizaLeitura(caminhoDoArquivoASerExibido);

        foreach (var pet in listaDepets)
        {
            System.Console.WriteLine(pet);
        }
    }
}