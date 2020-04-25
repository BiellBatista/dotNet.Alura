using _05_XX_ByteBank.Core.Model;
using _05_XX_ByteBank.Core.Repository;
using _05_XX_ByteBank.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace _05_XX_ByteBank.View
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
            BtnCancelar.IsEnabled = true;

            var progress = new Progress<string>(str => PgsProgresso.Value++);
            var resultado = await ConsolidarContas(contas, progress);
            var fim = DateTime.Now;

            AtualizarView(resultado, fim - inicio);
            BtnProcessar.IsEnabled = true;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            BtnCancelar.IsEnabled = false;
        }

        private async Task<string[]> ConsolidarContas(IEnumerable<ContaCliente> contas, IProgress<string> reportadorDeProgresso)
        {
            var tasks = contas.Select(c => Task.Factory.StartNew(() =>
            {
                var resultadoConsolidacao = r_Servico.ConsolidarMovimentacao(c);
                reportadorDeProgresso.Report(resultadoConsolidacao);

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
