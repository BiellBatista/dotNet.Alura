namespace _02_XX_Melhorando_Legibilidade.Console;

internal class Show
{
    public void ExibeConteudoArquivo(string caminhoDoArquivoASerExibido)
    {
        LeitorDeArquivo leitor = new LeitorDeArquivo();

        var listaDepets = leitor.RealizaLeitura(caminhoDoArquivoASerExibido);

        foreach (var pet in listaDepets)
        {
            System.Console.WriteLine(pet);
        }
    }
}