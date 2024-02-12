using _03_04_XX_Entendendo_OCP.Console.Servicos.Arquivos;
using _03_04_XX_Entendendo_OCP.Console.Servicos.Http;

namespace _03_04_XX_Entendendo_OCP.Console.Comandos;

public class ImportFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(Import)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var httpClientPet = new PetService(new AdopetAPIClientFactory().CreateClient("adopet"));
        var leitorDeArquivos = LeitorDeArquivosFactory.CreatePetFrom(argumentos[1]);
        if (leitorDeArquivos is null) { return null; }
        return new Import(httpClientPet, leitorDeArquivos);
    }
}