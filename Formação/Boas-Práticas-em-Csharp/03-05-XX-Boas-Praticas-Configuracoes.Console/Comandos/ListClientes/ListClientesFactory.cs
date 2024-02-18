using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Http;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Settings;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Comandos.ListClientes;

public class ListClientesFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(ListClientes)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var service = new ClienteService(new AdopetAPIClientFactory(Configurations.ApiSettings.Uri).CreateClient("adopet"));
        return new ListClientes(service);
    }
}