using _03_05_XX_Boas_Praticas_Configuracoes.Console.Modelos;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Abstracoes;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Arquivos;

public static class LeitorDeArquivoFactory
{
    public static ILeitorDeArquivo<Cliente>? CreateLeitorDeClientes(string caminhoArquivo)
    {
        return Path.GetExtension(caminhoArquivo) switch
        {
            ".csv" => new ClientesDoCsv(caminhoArquivo),
            ".json" => new ClientesDoJson(caminhoArquivo),
            _ => null
        };
    }

    public static ILeitorDeArquivo<Pet>? CreateLeitorDePets(string caminhoArquivo)
    {
        return Path.GetExtension(caminhoArquivo) switch
        {
            ".csv" => new PetsDoCsv(caminhoArquivo),
            ".json" => new PetsDoJson(caminhoArquivo),
            _ => null
        };
    }
}