using _03_05_XX_Boas_Praticas_Configuracoes.Console.Modelos;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Arquivos;

public class PetsDoJson : LeitorDeArquivoJson<Pet>
{
    public PetsDoJson(string caminhoArquivo) : base(caminhoArquivo)
    {
    }
}