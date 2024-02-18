using _03_05_XX_Boas_Praticas_Configuracoes.Console.Results;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Abstracoes;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Arquivos;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Email;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Http;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Settings;
using FluentResults;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Comandos.Import;

public class ImportFactory : IComandoFactory
{
    private IConfiguration _config;

    private IEmailService CriarEmailService()
    {
        MailSettings emailOptions = Configurations.MailSettings;
        var smtpClient = new SmtpClient()
        {
            Host = emailOptions.Servidor,
            Port = emailOptions.Porta,
            EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(emailOptions.Usuario, emailOptions.Senha)
        };
        return new SmtpClientEmailService(smtpClient);
    }

    private void EnviaEmailAposImportacao(Result resultado)
    {
        ISuccess? success = resultado.Successes.FirstOrDefault();
        if (success is null) return;

        if (success is SuccessWithPets sucesso)
        {
            MailSettings emailOptions = Configurations.MailSettings;

            var emailService = CriarEmailService();
            emailService.SendMessageAsync(
                remetente: emailOptions.EmailAdmin,
                titulo: $"[Adopet] {sucesso.Message}",
                corpo: $"Foram importados {sucesso.Data.Count()} pets.",
                destinatario: emailOptions.Usuario
            );
        }
    }

    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(Import)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var uri = Configurations.ApiSettings.Uri;
        var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory(uri).CreateClient("adopet"));
        var leitorDeArquivos = LeitorDeArquivoFactory.CreateLeitorDePets(argumentos[1]);
        if (leitorDeArquivos is null) return null;
        var comando = new Import(httpClientPet, leitorDeArquivos);
        comando.DepoisDaExecucao += EnviaEmailAposImportacao;
        return comando;
    }
}