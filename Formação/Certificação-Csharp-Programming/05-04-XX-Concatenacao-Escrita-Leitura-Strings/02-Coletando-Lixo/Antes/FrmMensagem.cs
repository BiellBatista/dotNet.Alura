using System;
using System.Windows.Forms;

namespace _05_04_XX_Concatenacao_Escrita_Leitura_Strings.Antes
{
    public partial class FrmMensagem : Form
    {
        public FrmMensagem()
        {
            InitializeComponent();
        }

        private void btnMensagem_Click(object sender, EventArgs e)
        {
            MensageiroNotepad mensageiro = new MensageiroNotepad();
            mensageiro.EnviarMensagem(txtMensagem.Text);
        }
    }
}