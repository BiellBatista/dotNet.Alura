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
            /**
             * Eu posso combinar dois métodos delegates, porque eles são feitos para serem manipulados
             */
            var okEventHandler = (RoutedEventHandler)btnOk_Click + Fechar;
            // realizando a combinação, é equivalente ao de cima. Na verdade, é isso que o compilador faz, por baixo do pano
            var cancelarEventHandler = (RoutedEventHandler)Delegate.Combine((RoutedEventHandler)btnCancelar_Click, (RoutedEventHandler)Fechar);

            // não preciso do bloco abaixo, porque eu já combinei os métodos delegate
            //btnOk.Click += new RoutedEventHandler(btnOk_Click);
            ///**
            // * Adicionado um novo comportamento ao evento de click
            // * Eu só passo adicionar ou remover comportamentos, não posso atribuia (sobrescrever) os já existente
            // * += ou -=
            // */
            //btnCancelar.Click += new RoutedEventHandler(btnCancelar_Click);

            //btnOk.Click += new RoutedEventHandler(Fechar);
            //btnCancelar.Click += new RoutedEventHandler(Fechar);

            // como eu combinei os métodos delegate, eu posso fazer isso:
            btnOk.Click += okEventHandler;
            btnCancelar.Click += cancelarEventHandler;
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
