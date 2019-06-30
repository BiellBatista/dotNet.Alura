using Passagens;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Host
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ClienteService));
            // criando o endpoint
            Uri endereco = new Uri("http://localhost:8080/cliente");
            host.AddServiceEndpoint(typeof(IClienteService), new BasicHttpBinding(), endereco);
            //todo endpoint tem um contrato, um binding (protocolo que irei usar para me comunicar) e um caminho

            try
            {
                host.Open();
                ExibeInformacoesServico(host);
                Console.ReadLine();
                host.Close();
            }
            catch (Exception ex)
            {
                host.Abort();
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        public static void ExibeInformacoesServico(ServiceHost sh)
        {
            Console.WriteLine("{0} online", sh.Description.ServiceType);

            foreach (ServiceEndpoint se in sh.Description.Endpoints)
                Console.WriteLine(se.Address);
        }
    }
}

/**
 * Para criar uma aplicação do tipo ServiceHost, devo adicionar as seguintes referências:
 * A DLL do meu serviço (WCF criado nas 02 e 03)
 * E System.ServiceModel
 * 
 * Esta aplicação sobe o serviço (Passagens/WCF/DLL)
 */
