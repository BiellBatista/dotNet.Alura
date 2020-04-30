using _02_XX_ByteBank.Agencias.DAL;
using System;
using System.Windows;

namespace _02_XX_ByteBank.Agencias
{
    /// <summary>
    /// Interaction logic for EdicaoAgencia.xaml
    /// </summary>
    public partial class EdicaoAgencia : Window
    {
        private readonly Agencia _agencia;

        public EdicaoAgencia(Agencia agencia)
        {
            InitializeComponent();

            _agencia = agencia ?? throw new ArgumentNullException(nameof(agencia));
            AtualizarCamposDeTexto();
            AtualizarControles();
        }

        private void AtualizarCamposDeTexto()
        {
            txtNumero.Text = _agencia.Numero;
            txtNome.Text = _agencia.Nome;
            txtTelefone.Text = _agencia.Telefone;
            txtEndereco.Text = _agencia.Endereco;
            txtDescricao.Text = _agencia.Descricao;
        }

        private void AtualizarControles()
        {
            btnOk.Click += new RoutedEventHandler(btnOk_Click);
            /**
             * Adicionado um novo comportamento ao evento de click
             * Eu só passo adicionar ou remover comportamentos, não posso atribuia (sobrescrever) os já existente
             * += ou -=
             */
            btnCancelar.Click += new RoutedEventHandler(btnCancelar_Click);

            btnOk.Click += new RoutedEventHandler(Fechar);
            btnCancelar.Click += new RoutedEventHandler(Fechar);
        }

        private void btnOk_Click(object sender, RoutedEventArgs e) => DialogResult = true;


        private void btnCancelar_Click(object sender, RoutedEventArgs e) =>
            // altera o resultado da visualização da janela
            DialogResult = false;

        private void Fechar(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
