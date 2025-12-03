using _03_06_XX_Enviando_Email.Console.Servicos.Arquivos;
using _03_06_XX_Enviando_Email.Console.Servicos.Http;
using _03_06_XX_Enviando_Email.Console.Settings;

namespace _03_06_XX_Enviando_Email.Console.Comandos;

public class ImportClientesFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(ImportClientes)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var service = new ClienteService(new AdopetAPIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));
        var leitorDeArquivosCliente = LeitorDeArquivosFactory.CreateClienteFrom(argumentos[1]);
        if (leitorDeArquivosCliente is null) { return null; }
        return new ImportClientes(service, leitorDeArquivosCliente);
    }
}