using _01_XX_ByteBank.Core.Model;
using _01_XX_ByteBank.Core.Repository;
using _01_XX_ByteBank.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _01_XX_ByteBank.View
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
            var contas = r_Repositorio.GetContaClientes();
            var contasQuantiadePorThread = contas.Count() / 4;

            var contas_parte1 = contas.Take(contasQuantiadePorThread);
            var contas_parte2 = contas.Skip(contasQuantiadePorThread).Take(contasQuantiadePorThread);
            var contas_parte3 = contas.Skip(contasQuantiadePorThread * 2).Take(contasQuantiadePorThread);
            var contas_parte4 = contas.Skip(contasQuantiadePorThread * 3);

            var resultado = new List<string>();

            AtualizarView(new List<string>(), TimeSpan.Zero);

            var inicio = DateTime.Now;

            // criando a primeira thread. Não estou executando ela
            Thread thread_part1 = new Thread(() =>
            {
                foreach (var conta in contas_parte1)
                {
                    var resultadoProcessamento = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(resultadoProcessamento);
                }
            });

            // criando a segunda thread. Não estou executando ela
            Thread thread_part2 = new Thread(() =>
            {
                foreach (var conta in contas_parte2)
                {
                    var resultadoProcessamento = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(resultadoProcessamento);
                }
            });

            Thread thread_part3 = new Thread(() =>
            {
                foreach (var conta in contas_parte2)
                {
                    var resultadoProcessamento = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(resultadoProcessamento);
                }
            });

            Thread thread_part4 = new Thread(() =>
            {
                foreach (var conta in contas_parte2)
                {
                    var resultadoProcessamento = r_Servico.ConsolidarMovimentacao(conta);
                    resultado.Add(resultadoProcessamento);
                }
            });

            thread_part1.Start();
            thread_part2.Start();
            thread_part3.Start();
            thread_part4.Start();

            while (thread_part1.IsAlive || thread_part2.IsAlive || thread_part3.IsAlive || thread_part4.IsAlive)
            {
                // este método irá colocar a thread para dormir (ela não consumirá processamento) por 250 milisegundos
                Thread.Sleep(250);
            }

            // nao preciso disso apos criar as thread
            //foreach (var conta in contas)
            //{
            //    var resultadoConta = r_Servico.ConsolidarMovimentacao(conta);
            //    resultado.Add(resultadoConta);
            //}

            var fim = DateTime.Now;

            AtualizarView(resultado, fim - inicio);
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
