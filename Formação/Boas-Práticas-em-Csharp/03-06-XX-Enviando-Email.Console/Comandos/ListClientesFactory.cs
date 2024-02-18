using _03_06_XX_Enviando_Email.Console.Servicos.Http;
using _03_06_XX_Enviando_Email.Console.Settings;

namespace _03_06_XX_Enviando_Email.Console.Comandos;

public class ListClientesFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(ListClientes)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var clienteService = new ClienteService(new AdopetAPIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));
        return new ListClientes(clienteService);
    }
}