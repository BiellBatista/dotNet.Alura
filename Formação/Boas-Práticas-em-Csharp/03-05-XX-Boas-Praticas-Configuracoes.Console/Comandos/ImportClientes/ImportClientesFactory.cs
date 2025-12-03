using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Arquivos;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Http;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Settings;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Comandos.ImportClientes;

public class ImportClientesFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(ImportClientes)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var uri = Configurations.ApiSettings.Uri;
        var serviceClientes = new ClienteService(new AdopetAPIClientFactory(uri).CreateClient("adopet"));
        var leitorArquivoClientes = LeitorDeArquivoFactory.CreateLeitorDeClientes(argumentos[1]);
        if (leitorArquivoClientes is null) return null;
        return new ImportClientes(serviceClientes, leitorArquivoClientes);
    }
}