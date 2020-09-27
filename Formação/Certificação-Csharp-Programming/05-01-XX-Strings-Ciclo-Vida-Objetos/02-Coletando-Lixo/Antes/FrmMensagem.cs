using System;
using System.Windows.Forms;

namespace _05_01_XX_Strings_Ciclo_Vida_Objetos.Antes
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
