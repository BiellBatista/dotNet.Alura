using System;
using System.Windows.Forms;
using Consumidor.Passagens;

namespace Consumidor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string cpf = txtCpf.Text;

            try
            {
                ClienteServiceClient servico = new ClienteServiceClient();
                Cliente clienteCadastro = new Cliente();

                clienteCadastro.Nome = nome;
                clienteCadastro.Cpf = cpf;

                servico.Add(clienteCadastro); //mando o cliente para o servico

                MessageBox.Show("Cliente cadastrado com sucesso!");
            }
            catch(Exception)
            {
                //salva um log
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;

            try
            {
                ClienteServiceClient servico = new ClienteServiceClient();

                Cliente resultado = servico.Buscar(nome); //busco o cliente do servico

                txtCpf.Text = resultado.Cpf;
            }
            catch (Exception)
            {
                //salva um log
            }
        }
    }
}
