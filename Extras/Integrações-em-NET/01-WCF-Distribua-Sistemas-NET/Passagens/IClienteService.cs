using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Passagens
{
    // esta tag serve para informar que esta interface é um contrato do WCF
    [ServiceContract]
    public interface IClienteService
    {
        // esta tag serve para informar que o método (operacao) faz parte do contrato
        [OperationContract]
        // esta anotacao(tag) serve para indicar que esta operacao pode ser acessada pelo browser. Além disso, irei me comunicar pelo get
        //com a resposta do servico em XML e com o template URI X
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "addCliente/{nome};{cpf}")]
        bool Add(string nome, string cpf);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "searchCliente/{nome}")]
        Cliente Buscar(string nome);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "getClientes/")]
        List<Cliente> getClientes();
    }
}
