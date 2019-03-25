using System.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace ASP_NET_Identity_Parte_4.App_Start.Identity
{
    // criando a classe que irá enviar o código de verificação do usuário
    public class SMSServico : IIdentityMessageService
    {
        private readonly string TWILIO_SID = ConfigurationManager.AppSettings["twilio:SID"];
        private readonly string TWILIO_AUTH_TOKEN = ConfigurationManager.AppSettings["twilio:auth_token"];
        private readonly string TWILIO_FROM_NUMBER = ConfigurationManager.AppSettings["twilio:from_phone"];

        public async Task SendAsync(IdentityMessage message)
        {
            TwilioClient.Init(TWILIO_SID, TWILIO_AUTH_TOKEN);
            await MessageResource.CreateAsync(
                new PhoneNumber(message.Destination),
                from: TWILIO_FROM_NUMBER,
                body: message.Body);
        }
    }
}