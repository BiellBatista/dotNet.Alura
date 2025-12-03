using _03_01_XX_Importando_Json.Console.Modelos;
using _03_01_XX_Importando_Json.Console.Servicos.Abstracoes;
using System.Text.Json;

namespace _03_01_XX_Importando_Json.Console.Servicos.Arquivos;

public class LeitorDeArquivosJson : ILeitorDeArquivos
{
    private string caminhoArquivo;

    public LeitorDeArquivosJson(string caminhoArquivo)
    {
        this.caminhoArquivo = caminhoArquivo;
    }

    public IEnumerable<Pet> RealizaLeitura()
    {
        using var stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read);
        return JsonSerializer.Deserialize<IEnumerable<Pet>>(stream) ?? Enumerable.Empty<Pet>();
    }
}