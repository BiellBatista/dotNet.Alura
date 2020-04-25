using _03_XX_ByteBank.Core.Model;
using _03_XX_ByteBank.Core.Repository;
using _03_XX_ByteBank.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace _03_XX_ByteBank.View
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

        private void BtnProcessar_Click(object sender, RoutedEventArgs e)
        {
            BtnProcessar.IsEnabled = false;

            var taskSchedulerUI = TaskScheduler.FromCurrentSynchronizationContext();
            var contas = r_Repositorio.GetContaClientes();

            AtualizarView(new List<string>(), TimeSpan.Zero);

            var inicio = DateTime.Now;
            // este é o mesmo esquema do callback em JS
            ConsolidarContas(contas)
                .ContinueWith(t =>
                {
                    var fim = DateTime.Now;
                    var resultado = t.Result;
                    AtualizarView(resultado, fim - inicio);
                }, taskSchedulerUI)
                .ContinueWith(t =>
                {
                    BtnProcessar.IsEnabled = true;
                }, taskSchedulerUI);
        }

        private Task<List<string>> ConsolidarContas(IEnumerable<ContaCliente> contas)
        {
            var resultado = new List<string>();
            var tasks = contas.Select(c =>
            {
                return Task.Factory.StartNew(() =>
                {
                    var resultadoConta = r_Servico.ConsolidarMovimentacao(c);
                    resultado.Add(resultadoConta);
                });
            });

            return Task.WhenAll(tasks).ContinueWith(t =>
            {
                return resultado;
            });
        }

        private void AtualizarView(List<String> result, TimeSpan elapsedTime)
        {
            var tempoDecorrido = $"{ elapsedTime.Seconds }.{ elapsedTime.Milliseconds} segundos!";
            var mensagem = $"Processamento de {result.Count} clientes em {tempoDecorrido}";

            LstResultados.ItemsSource = result;
            TxtTempo.Text = mensagem;
        }
    }
}
