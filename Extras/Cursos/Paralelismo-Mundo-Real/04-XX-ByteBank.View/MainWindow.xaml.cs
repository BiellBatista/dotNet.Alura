﻿using _04_XX_ByteBank.Core.Model;
using _04_XX_ByteBank.Core.Repository;
using _04_XX_ByteBank.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace _04_XX_ByteBank.View
{
    public partial class MainWindow : Window
    {
        private readonly ContaClienteRepository r_Repositorio;
        private readonly ContaClienteService r_Servico;

        public MainWindow()
        {
            InitializeComponent();

            r_Repositorio = new ContaClienteRepository();
            r_Servico = new ContaClienteService();
        }

        private async void BtnProcessar_Click(object sender, RoutedEventArgs e)
        {
            BtnProcessar.IsEnabled = false;
            var contas = r_Repositorio.GetContaClientes();

            PgsProgresso.Maximum = contas.Count();

            LimparView();

            var inicio = DateTime.Now;
            var resultado = await ConsolidarContas(contas);
            var fim = DateTime.Now;

            AtualizarView(resultado, fim - inicio);
            BtnProcessar.IsEnabled = true;
        }

        private async Task<string[]> ConsolidarContas(IEnumerable<ContaCliente> contas)
        {
            var taskSchedulerGui = TaskScheduler.FromCurrentSynchronizationContext();
            var tasks = contas.Select(c => Task.Factory.StartNew(() =>
            {
                var resultadoConsolidacao = r_Servico.ConsolidarMovimentacao(c);

                Task.Factory.StartNew(
                    () => PgsProgresso.Value++,
                    CancellationToken.None,
                    TaskCreationOptions.None,
                    taskSchedulerGui
                    );

                return resultadoConsolidacao;
            })
            );

            return await Task.WhenAll(tasks);
        }

        private void LimparView()
        {
            LstResultados.ItemsSource = null;
            TxtTempo.Text = null;
            PgsProgresso.Value = 0;
        }

        private void AtualizarView(IEnumerable<String> result, TimeSpan elapsedTime)
        {
            var tempoDecorrido = $"{ elapsedTime.Seconds }.{ elapsedTime.Milliseconds} segundos!";
            var mensagem = $"Processamento de {result.Count()} clientes em {tempoDecorrido}";

            LstResultados.ItemsSource = result;
            TxtTempo.Text = mensagem;
        }
    }
}
