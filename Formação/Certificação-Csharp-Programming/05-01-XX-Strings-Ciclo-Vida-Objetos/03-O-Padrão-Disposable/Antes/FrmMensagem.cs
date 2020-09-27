using System;
using System.Windows.Forms;

namespace _05_01_XX_Strings_Ciclo_Vida_Objetos.Antes
{
    public partial class FrmMensagem2 : Form
    {
        public FrmMensagem2()
        {
            InitializeComponent();
        }

        private void btnMensagem_Click(object sender, EventArgs e)
        {
            MensageiroNotepad2 mensageiro = new MensageiroNotepad2();
            mensageiro.EnviarMensagem(txtMensagem.Text);
        }
    }
}
