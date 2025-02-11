﻿using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace _05_05_XX_Pesquisando_Strings.Antes
{
    public partial class FrmPesquisa : Form
    {
        public FrmPesquisa()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void rbt_CheckedChanged(object sender, EventArgs e)
        {
            btnExecutar.Enabled = true;
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            var checkedButton = pnlBotoes.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);

            if (checkedButton != null)
            {
                string tipoComando = checkedButton.Tag as string;
                if (tipoComando != null)
                {
                    var parametros = pnlBotoes.Controls.OfType<TextBox>()
                          .Where(t => t.Name.StartsWith("txt" + tipoComando))
                          .OrderBy(t => t.Name)
                          .Select(t => t.Text)
                          .ToList();

                    Pesquisa pesquisa = new Pesquisa(lblDocumento, parametros);
                    string resultado = pesquisa.ExecutarComando(tipoComando);
                    MessageBox.Show(resultado);
                }
            }
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                var tag = textBox.Tag as string;

                var button = pnlBotoes.Controls.OfType<RadioButton>()
                          .FirstOrDefault(r => r.Tag.ToString() == tag);

                if (button != null)
                {
                    button.Checked = true;
                }

                var otherTextBoxes = pnlBotoes.Controls.OfType<TextBox>()
                    .Where(r => r.Tag.ToString() != tag);

                foreach (var item in otherTextBoxes)
                {
                    item.Text = "";
                }
            }
        }
    }
}