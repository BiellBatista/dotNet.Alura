using System;

namespace _04_09_XX_Facades_Singletons.Bridges
{
    public class MensagemCliente : IMensagem
    {
        private string nome;

        public IEnviador Enviador { get; set; }

        public MensagemCliente(String nome)
        {
            this.nome = nome;
        }

        public string Formata()
        {
            return String.Format("Mensagem para o cliente {0}", nome);
        }

        public void Envia()
        {
            this.Enviador.Envia(this);
        }
    }
}
