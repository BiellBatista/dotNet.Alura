using System.Runtime.Serialization;

namespace Passagens
{
    [DataContract]
    public class Cliente
    {
        // esta tag (anotacao) fala quais os atributos que devem ser nevegável pelo serviço
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Cpf { get; set; }
    }
}
