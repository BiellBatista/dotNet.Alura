using _03_06_XX_Enviando_Email.Console.Servicos.Http;
using _03_06_XX_Enviando_Email.Console.Settings;

namespace _03_06_XX_Enviando_Email.Console.Comandos;

public class ListFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(List)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var httpClientPetList = new PetService(new AdopetAPIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));
        return new List(httpClientPetList);
    }
}