using System;
using System.Windows.Forms;

namespace _05_04_XX_Concatenacao_Escrita_Leitura_Strings.Depois
{
    public partial class FrmMensagem2 : Form
    {
        public FrmMensagem2()
        {
            InitializeComponent();
        }

        private void btnMensagem_Click(object sender, EventArgs e)
        {
            //MensageiroNotepad mensageiro = new MensageiroNotepad();
            //mensageiro.EnviarMensagem(txtMensagem.Text);
            //mensageiro.Dispose();
            using (MensageiroNotepad mensageiro = new MensageiroNotepad())
            {
                mensageiro.EnviarMensagem(txtMensagem.Text);
            }
        }
    }
}
