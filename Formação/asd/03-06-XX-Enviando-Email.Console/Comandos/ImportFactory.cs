using _03_06_XX_Enviando_Email.Console.Servicos.Arquivos;
using _03_06_XX_Enviando_Email.Console.Servicos.Http;
using _03_06_XX_Enviando_Email.Console.Servicos.Mail;
using _03_06_XX_Enviando_Email.Console.Settings;

namespace _03_06_XX_Enviando_Email.Console.Comandos;

public class ImportFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(Import)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var httpClientPet = new PetService(new AdopetAPIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));
        var leitorDeArquivos = LeitorDeArquivosFactory.CreatePetFrom(argumentos[1]);
        if (leitorDeArquivos is null) { return null; }
        var import = new Import(httpClientPet, leitorDeArquivos);
        import.DepoisDaExecucao += EnvioDeEmail.Disparar;
        return import;
    }
}