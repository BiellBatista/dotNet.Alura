using _03_04_XX_Entendendo_OCP.Console.Servicos.Arquivos;
using _03_04_XX_Entendendo_OCP.Console.Servicos.Http;

namespace _03_04_XX_Entendendo_OCP.Console.Comandos;

public class ImportClientesFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(ImportClientes)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var service = new ClienteService(new AdopetAPIClientFactory().CreateClient("adopet"));
        var leitorDeArquivosCliente = LeitorDeArquivosFactory.CreateClienteFrom(argumentos[1]);
        if (leitorDeArquivosCliente is null) { return null; }
        return new ImportClientes(service, leitorDeArquivosCliente);
    }
}