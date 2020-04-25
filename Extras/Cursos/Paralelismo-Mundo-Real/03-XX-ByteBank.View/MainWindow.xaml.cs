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
            // o TaskScheduler existe na thread principal da aplicação
            // o método "FromCurrentSynchronizationContext", retorna o this da thread que ele está sendo executado. Neste caso, é a principal
            var taskSchedulerUI = TaskScheduler.FromCurrentSynchronizationContext();
            BtnProcessar.IsEnabled = false;
            var contas = r_Repositorio.GetContaClientes();

            var resultado = new List<string>();

            AtualizarView(new List<string>(), TimeSpan.Zero);

            var inicio = DateTime.Now;

            var contasTarefas = contas.Select(c =>
            {
                // o cara responsável por gerenciar os núcleos. Ele dividi cada tarefa em uma thread
                return Task.Factory.StartNew(() =>
                {
                    // o método retorna o this desta thread, não é a principal
                    // TaskScheduler.FromCurrentSynchronizationContext();
                    var resultadoConta = r_Servico.ConsolidarMovimentacao(c);
                    resultado.Add(resultadoConta);
                });
            }).ToArray();

            // espera todas as tarefas de "contasTarefas" ser concluida
            // Task.WaitAll(contasTarefas);

            // enquanto as tarefas são realizadas, faça
            Task.WhenAll(contasTarefas)
                .ContinueWith(t =>
                {
                    var fim = DateTime.Now;
                    // o método retorna o this desta thread, não é a principal
                    // TaskScheduler.FromCurrentSynchronizationContext();
                    AtualizarView(resultado, fim - inicio);
                }, taskSchedulerUI)
                .ContinueWith(t =>
                {
                    BtnProcessar.IsEnabled = true;
                }, taskSchedulerUI);
            // o segundo parametro passa o this da thread principal, para que seja possível pegar os atributos dela
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
