using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Abstracoes;
using System.Text.Json;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Arquivos;

public abstract class LeitorDeArquivoJson<T> : ILeitorDeArquivo<T>
{
    private string caminhoArquivo;

    public LeitorDeArquivoJson(string caminhoArquivo)
    {
        this.caminhoArquivo = caminhoArquivo;
    }

    public IEnumerable<T> RealizaLeitura()
    {
        using Stream stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read);
        JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };
        return JsonSerializer.Deserialize<IEnumerable<T>>(stream, options) ?? Enumerable.Empty<T>();
    }
}