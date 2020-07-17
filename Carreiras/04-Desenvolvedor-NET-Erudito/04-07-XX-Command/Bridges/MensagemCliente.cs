using System;

namespace _04_07_XX_Command.Bridges
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
