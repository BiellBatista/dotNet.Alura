using _03_01_XX_Importando_Json.Console.Servicos.Abstracoes;

namespace _03_01_XX_Importando_Json.Console.Servicos.Arquivos;

public static class LeitorDeArquivosFactory
{
    public static ILeitorDeArquivos? CreatePetFrom(string caminhoArquivo)
    {
        var extensao = Path.GetExtension(caminhoArquivo);
        switch (extensao)
        {
            case ".csv":
                return new LeitorDeArquivoCsv(caminhoArquivo);

            case ".json":
                return new LeitorDeArquivosJson(caminhoArquivo);

            default: return null;
        }
    }
}