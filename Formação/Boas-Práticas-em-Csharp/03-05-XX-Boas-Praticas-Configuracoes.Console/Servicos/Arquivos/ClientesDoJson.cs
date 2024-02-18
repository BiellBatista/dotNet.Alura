using _03_05_XX_Boas_Praticas_Configuracoes.Console.Modelos;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Arquivos;

public class ClientesDoJson : LeitorDeArquivoJson<Cliente>
{
    public ClientesDoJson(string caminhoArquivo) : base(caminhoArquivo)
    {
    }
}