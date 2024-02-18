using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Http;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Settings;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Comandos.List;

public class ListFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(List)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var httpClientPetList = new HttpClientPet(new AdopetAPIClientFactory(Configurations.ApiSettings.Uri).CreateClient("adopet"));
        return new List(httpClientPetList);
    }
}