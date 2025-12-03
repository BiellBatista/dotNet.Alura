using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Abstracoes;
using System.Net.Mail;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Email;

public class SmtpClientEmailService : IEmailService
{
    private readonly SmtpClient smtpClient;

    public SmtpClientEmailService(SmtpClient smtpClient)
    {
        this.smtpClient = smtpClient;
    }

    public Task SendMessageAsync(
        string destinatario,
        string titulo,
        string corpo,
        string remetente)
    {
        var message = new MailMessage
        {
            From = new MailAddress(remetente),
            Subject = titulo,
            Body = corpo
        };

        message.To.Add(new MailAddress(destinatario));

        smtpClient.Send(message);
        return Task.CompletedTask;
    }
}