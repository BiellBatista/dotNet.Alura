﻿using _01_XX_ByteBank.Agencias.DAL;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace _01_XX_ByteBank.Agencias
{ 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ByteBankEntities _contextoBancoDeDados = new ByteBankEntities();
        private readonly AgenciasListBox lstAgencias;

        public MainWindow()
        {
            InitializeComponent();

            lstAgencias = new AgenciasListBox(this);
            AtualizarControles();
        }

        private void AtualizarControles()
        {
            lstAgencias.Width = 270;
            lstAgencias.Height = 290;

            Canvas.SetTop(lstAgencias, 15);
            Canvas.SetLeft(lstAgencias, 15);

            container.Children.Add(lstAgencias);

            lstAgencias.Items.Clear();
            var agencias = _contextoBancoDeDados.Agencias.ToList();
            foreach (var agencia in agencias)
                lstAgencias.Items.Add(agencia);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var confirmacao = 
                MessageBox.Show(
                    "Você deseja realmente excluir este item?",
                    "Confirmação",
                    MessageBoxButton.YesNo);
            if (confirmacao == MessageBoxResult.Yes)
            {
                //Excluir
            }
            else
            {
                //Não faz nada
            }
        }
    }
}
