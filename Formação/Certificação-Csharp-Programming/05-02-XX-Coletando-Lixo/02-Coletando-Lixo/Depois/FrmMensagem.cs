﻿using System;
using System.Windows.Forms;

namespace _05_02_XX_Coletando_Lixo.Depois
{
    public partial class FrmMensagem : Form
    {
        public FrmMensagem()
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