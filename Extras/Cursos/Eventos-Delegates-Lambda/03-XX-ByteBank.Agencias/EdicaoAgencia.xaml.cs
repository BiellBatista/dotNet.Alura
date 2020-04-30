﻿using _03_XX_ByteBank.Agencias.DAL;
using System;
using System.Windows;

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
            var okEventHandler = (RoutedEventHandler)btnOk_Click + Fechar;
            var cancelarEventHandler = (RoutedEventHandler)btnCancelar_Click + Fechar;

            btnOk.Click += okEventHandler;
            btnCancelar.Click += cancelarEventHandler;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e) => DialogResult = true;


        private void btnCancelar_Click(object sender, RoutedEventArgs e) => DialogResult = false;

        private void Fechar(object sender, RoutedEventArgs e) => Close();
    }
}
