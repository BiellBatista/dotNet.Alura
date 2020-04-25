using _05_XX_ByteBank.Core.Model;
using _05_XX_ByteBank.Core.Repository;
using _05_XX_ByteBank.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace _05_XX_ByteBank.View
{
    public partial class MainWindow : Window
    {
        private readonly ContaClienteRepository r_Repositorio;
        private readonly ContaClienteService r_Servico;
        private CancellationTokenSource _cts;

        public MainWindow()
        {
            InitializeComponent();

            r_Repositorio = new ContaClienteRepository();
            r_Servico = new ContaClienteService();
        }

        private async void BtnProcessar_Click(object sender, RoutedEventArgs e)
        {
            BtnProcessar.IsEnabled = false;

            // são as tarefas que irão usar o CancellationTokenSource
            _cts = new CancellationTokenSource();

            var contas = r_Repositorio.GetContaClientes();

            PgsProgresso.Maximum = contas.Count();

            LimparView();

            var inicio = DateTime.Now;
            BtnCancelar.IsEnabled = true;

            var progress = new Progress<string>(str => PgsProgresso.Value++);

            try
            {
                var resultado = await ConsolidarContas(contas, progress, _cts.Token);
                var fim = DateTime.Now;
                AtualizarView(resultado, fim - inicio);
            }
            catch (OperationCanceledException)
            {
                TxtTempo.Text = "Operação cancelada pelo usuário.";
            }
            finally
            {
                BtnProcessar.IsEnabled = true;
                BtnCancelar.IsEnabled = false;
            }

        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            BtnCancelar.IsEnabled = false;
            // este método altera o estado o cts e todos que estiverem utilizando o objeto, saberão que a ação foi cancelada
            _cts.Cancel();
        }

        private async Task<string[]> ConsolidarContas(IEnumerable<ContaCliente> contas, IProgress<string> reportadorDeProgresso, CancellationToken ct)
        {
            var tasks = contas.Select(c =>
                Task.Factory.StartNew(() =>
                {
                    // devo sempre verificar se o usuário cancelou, mesmo passando o CancellationToken, porque o usuário
                    // pode cancelar depois da verificação do método StartNew
                    // não preciso mais desse if, porque estou utilizando o throw do ct
                    //if (ct.IsCancellationRequested)
                    //    throw new OperationCanceledException(ct);
                    // retorna uma exceção, caso a operação seja cancelada
                    ct.ThrowIfCancellationRequested();

                    var resultadoConsolidacao = r_Servico.ConsolidarMovimentacao(c, ct);
                    reportadorDeProgresso.Report(resultadoConsolidacao);

                    // não preciso mais desse if, porque estou utilizando o throw do ct
                    //if (ct.IsCancellationRequested)
                    //    throw new OperationCanceledException(ct);
                    // retorna uma exceção, caso a operação seja cancelada
                    ct.ThrowIfCancellationRequested();

                    return resultadoConsolidacao;
                    //passando o CacellationToken para o método da thread, da qual ele irá sempre verificar se a operação foi cancelada
                    // caso a operação seja cancelada, ele não irá agendar uma nova thread
                }, ct)
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
