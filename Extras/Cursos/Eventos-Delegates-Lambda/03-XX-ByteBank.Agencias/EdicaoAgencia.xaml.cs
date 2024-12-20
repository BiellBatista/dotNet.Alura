﻿using _03_XX_ByteBank.Agencias.DAL;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _03_XX_ByteBank.Agencias
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
            // declarando o método btnOk_Click no modo anonimo
            //RoutedEventHandler dialogResultTrue = delegate (object sender, RoutedEventArgs e) { DialogResult = true; };
            // isso é a equivalencia do de cima
            RoutedEventHandler dialogResultTrue = (sender, e) => DialogResult = true;
            // declarando o método btnCancelar_Click no modo anonimo
            //RoutedEventHandler dialogResultFalse = delegate (object sender, RoutedEventArgs e) { DialogResult = false; };
            RoutedEventHandler dialogResultFalse = (sender, e) => DialogResult = false;

            // não preciso mais disso, porque estou utilizando um açuca sintatico
            //var okEventHandler = (RoutedEventHandler)btnOk_Click + Fechar;
            //var cancelarEventHandler = (RoutedEventHandler)btnCancelar_Click + Fechar;

            var okEventHandler = dialogResultTrue + Fechar;
            var cancelarEventHandler = dialogResultFalse + Fechar;

            btnOk.Click += okEventHandler;
            btnCancelar.Click += cancelarEventHandler;

            txtNome.TextChanged += ValidarCampoNulo;
            txtDescricao.TextChanged += ValidarCampoNulo;
            txtEndereco.TextChanged += ValidarCampoNulo;
            txtNumero.TextChanged += ValidarCampoNulo;
            txtTelefone.TextChanged += ValidarCampoNulo;
        }

        private void ValidarCampoNulo(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            var textoEstaVazio = String.IsNullOrEmpty(txt.Text);

            txt.Background = textoEstaVazio
            ? new SolidColorBrush(Colors.OrangeRed)
            : new SolidColorBrush(Colors.White);
        }

        //private TextChangedEventHandler ConstruirDelegateValidacaoCampoNulo(TextBox txt)
        //{
        //    return (sender, e) =>
        //    {
        //        var textoEstaVazio = String.IsNullOrEmpty(txt.Text);

        //        txt.Background = textoEstaVazio
        //        ? new SolidColorBrush(Colors.OrangeRed)
        //        : new SolidColorBrush(Colors.White);
        //    };
        //}

        // não preciso deste método, porque o método de cima construi um delegate genérico
        //private void TxtNome_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        //{
        //    var textoEstaVazio = String.IsNullOrEmpty(txtNome.Text);

        //    if (textoEstaVazio)
        //        txtNome.Background = new SolidColorBrush(Colors.OrangeRed);
        //    else
        //        txtNome.Background = new SolidColorBrush(Colors.White);
        //}

        // não preciso mais desse método, porque eu estou o declarando anonimamende lá em cima
        //private void btnOk_Click(object sender, RoutedEventArgs e) => DialogResult = true;

        // não preciso mais desse método, porque eu estou o declarando anonimamende lá em cima
        //private void btnCancelar_Click(object sender, RoutedEventArgs e) => DialogResult = false;

        private void Fechar(object sender, RoutedEventArgs e) => Close();

        //contravariância é o processo de receber um parâmetro B, só que a assinatura espera o A
        //porém, o B é filho de A, com isso o compilador realizar um casting

        // não consigo aplicar a contravariância em métodos anonimos
    }
}
