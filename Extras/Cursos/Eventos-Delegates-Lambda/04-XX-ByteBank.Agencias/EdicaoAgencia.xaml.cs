using _04_XX_ByteBank.Agencias.DAL;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _04_XX_ByteBank.Agencias
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
            RoutedEventHandler dialogResultTrue = (sender, e) => DialogResult = true;
            RoutedEventHandler dialogResultFalse = (sender, e) => DialogResult = false;

            var okEventHandler = dialogResultTrue + Fechar;
            var cancelarEventHandler = dialogResultFalse + Fechar;

            btnOk.Click += okEventHandler;
            btnCancelar.Click += cancelarEventHandler;

            txtNumero.TextChanged += ValidarCampoNulo;
            txtNumero.TextChanged += ValidarSomenteNumero;

            txtNome.TextChanged += ValidarCampoNulo;
            txtDescricao.TextChanged += ValidarCampoNulo;
            txtEndereco.TextChanged += ValidarCampoNulo;
            txtTelefone.TextChanged += ValidarCampoNulo;
        }

        private void ValidarSomenteNumero(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            Func<char, bool> verificaSeEhDigito = caractere =>
            {
                return Char.IsDigit(caractere);
            };

            var todosOsCaracteresSaoDigitos = txt.Text.All(verificaSeEhDigito);

            txt.Background = todosOsCaracteresSaoDigitos
            ? new SolidColorBrush(Colors.White)
            : new SolidColorBrush(Colors.OrangeRed);
        }

        private void ValidarCampoNulo(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            var textoEstaVazio = String.IsNullOrEmpty(txt.Text);

            txt.Background = textoEstaVazio
            ? new SolidColorBrush(Colors.OrangeRed)
            : new SolidColorBrush(Colors.White);
        }

        private void Fechar(object sender, RoutedEventArgs e) => Close();
    }
}
