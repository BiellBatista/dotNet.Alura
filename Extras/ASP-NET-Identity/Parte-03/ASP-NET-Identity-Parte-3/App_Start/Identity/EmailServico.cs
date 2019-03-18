using Microsoft.AspNet.Identity;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ASP_NET_Identity_Parte_3.App_Start.Identity
{
    public class EmailServico : IIdentityMessageService
    {
        private readonly string EMAIL_ORIGEM = ConfigurationManager.AppSettings["emailServico:email_remetente"];
        private readonly string EMAIL_SENHA = ConfigurationManager.AppSettings["emailServico:email_senha"];

        public async Task SendAsync(IdentityMessage message)
        {
            using (var menssagemDeEmail = new MailMessage())
            {
                menssagemDeEmail.From = new MailAddress(EMAIL_ORIGEM);

                menssagemDeEmail.Subject = message.Subject;
                menssagemDeEmail.To.Add(message.Destination);
                menssagemDeEmail.Body = message.Body;

                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new NetworkCredential(EMAIL_ORIGEM, EMAIL_SENHA);

                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;

                    smtpClient.Timeout = 20_000;

                    await smtpClient.SendMailAsync(menssagemDeEmail);
                }
            }
        }
    }
}