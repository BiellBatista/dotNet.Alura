using System;

namespace _04_09_XX_Facades_Singletons.Bridges
{
    public class MensagemAdministrativa : IMensagem
    {
        private string nome;

        public IEnviador Enviador { get; set; }

        public MensagemAdministrativa(string nome)
        {
            this.nome = nome;
        }

        public string Formata()
        {
            return String.Format("Mensagem administrativa para {0}", nome);
        }

        public void Envia()
        {
            this.Enviador.Envia(this);
        }
    }
}
