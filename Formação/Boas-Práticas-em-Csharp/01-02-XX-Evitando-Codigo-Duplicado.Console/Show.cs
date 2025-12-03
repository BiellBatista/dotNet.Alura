namespace _01_02_XX_Evitando_Codigo_Duplicado.Console;

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