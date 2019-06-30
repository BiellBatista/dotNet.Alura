using System.ServiceModel;

namespace Passagens
{
    // esta tag serve para informar que esta interface é um contrato do WCF
    [ServiceContract]
    public interface IClienteService
    {
        // esta tag serve para informar que o método (operacao) faz parte do contrato
        [OperationContract]
        void Add(Cliente c);
        [OperationContract]
        Cliente Buscar(string nome);
    }
}
