using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace ASP_NET_Identity_Parte_1.App_Start.Identity
{
    // esta classe configura o envio de e-mail de confirmação de usuário
    // a interface IIdentityMessageService serve para enviar e-mail ou SMS
    public class EmailServico : IIdentityMessageService
    {
        private readonly string EMAIL_ORIGEM = ConfigurationManager.AppSettings["emailServico:email_remetente"];
        private readonly string EMAIL_SENHA = ConfigurationManager.AppSettings["emailServico:email_senha"];

        public async Task SendAsync(IdentityMessage message)
        {
            // o objeto MailMessage() configura a menssagem
            using (var menssagemDeEmail = new MailMessage())
            {
                menssagemDeEmail.From = new MailAddress(EMAIL_ORIGEM);

                menssagemDeEmail.Subject = message.Subject;
                menssagemDeEmail.To.Add(message.Destination);
                menssagemDeEmail.Body = message.Body;

                // SMTP - Simple Mail Transport Protocol (usado para transportar e-mail)
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