using _03_04_XX_Entendendo_OCP.Console.Servicos.Http;

namespace _03_04_XX_Entendendo_OCP.Console.Comandos;

public class ListClientesFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(ListClientes)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var clienteService = new ClienteService(new AdopetAPIClientFactory().CreateClient("adopet"));
        return new ListClientes(clienteService);
    }
}