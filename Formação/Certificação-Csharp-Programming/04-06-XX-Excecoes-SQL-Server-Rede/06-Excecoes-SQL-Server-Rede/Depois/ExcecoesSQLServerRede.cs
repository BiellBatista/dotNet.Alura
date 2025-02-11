﻿using System;
using System.Data.SqlClient;
using System.IO;

namespace _04_06_XX_Excecoes_SQL_Server_Rede.Depois
{
    internal class ExcecoesSQLServerRede : IAulaItem
    {
        public void Executar()
        {
            ContaCorrente6 conta1 = new ContaCorrente6(1, 100);
            ContaCorrente6 conta2 = new ContaCorrente6(4, 50);
            Console.WriteLine(conta1);
            Console.WriteLine(conta2);

            ITransferenciaBancaria6 transferencia = new TransferenciaBancaria_BD6();
            transferencia.Efetuar(conta1, conta2, 30);

            Console.WriteLine(conta1);
            Console.WriteLine(conta2);

            try
            {
                transferencia.Efetuar(conta1, conta2, 250);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Aconteceu um problema na transferência.");
                Logger.LogErro(ex.ToString());
            }

            Console.ReadKey();
        }
    }

    internal class ContaCorrente6
    {
        public int Id { get; }
        public decimal Saldo { get; private set; }

        public ContaCorrente6(int id, decimal saldo)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            Id = id;
            Saldo = saldo;
        }

        public void Debitar(decimal valor)
        {
            Saldo -= valor;
        }

        public void Creditar(decimal valor)
        {
            Saldo += valor;
        }

        public override string ToString()
        {
            return $"Conta Nº: {Id:0000}, Saldo: {Saldo:C}";
        }

        public void AtualizarSaldo(decimal novoSaldo)
        {
            Saldo = novoSaldo;
        }
    }

    internal interface ITransferenciaBancaria6
    {
        void Efetuar(ContaCorrente6 contaDebito, ContaCorrente6 contaCredito, decimal valor);
    }

    internal class TransferenciaBancaria6 : ITransferenciaBancaria6
    {
        public void Efetuar(ContaCorrente6 contaDebito, ContaCorrente6 contaCredito, decimal valor)
        {
            if (contaDebito == null)
            {
                throw new ArgumentNullException("contaDebito");
            }
            if (contaCredito == null)
            {
                throw new ArgumentNullException("contaCredito");
            }
            if (valor <= 0)
            {
                throw new ArgumentOutOfRangeException("valor");
            }
            if (valor > contaDebito.Saldo)
            {
                throw new SaldoInsuficienteException6();
            }

            Logger.LogInfo("Entrando do método Efetuar.");

            contaDebito.Debitar(valor);
            contaCredito.Creditar(valor);

            Logger.LogInfo("Transferência realizada com sucesso.");
            Logger.LogInfo("Saindo do método Efetuar.");
        }
    }

    internal class TransferenciaBancaria_BD6 : ITransferenciaBancaria6
    {
        private const string CONNECTION_STRING = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB\ByteBank.mdf;Integrated Security=True";
        private const decimal TAXA_TRANSFERENCIA = 1.0m;
        private SqlConnection connection;
        private SqlTransaction transaction;

        public void Efetuar(ContaCorrente6 contaCredito, ContaCorrente6 contaDebito, decimal valor)
        {
            Logger.LogInfo("Entrando do método Efetuar.");

            //CRIA CONEXÃO COM O BANCO DE DADOS E INICIA UMA TRANSAÇÃO
            connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            transaction = connection.BeginTransaction();

            //OBTÉM OS COMANDOS DO SQL SERVER
            SqlCommand comandoTransferencia = GetTransferenciaCommand(contaCredito.Id, contaDebito.Id, valor);
            SqlCommand comandoTaxa = GetTaxaTransferenciaCommand(contaCredito.Id, TAXA_TRANSFERENCIA);

            try
            {
                //EXECUTA OS COMANDOS NO SERVIDOR DE BANCO DE DADOS
                comandoTaxa.ExecuteNonQuery();
                comandoTransferencia.ExecuteNonQuery();
                transaction.Commit(); //A TRANSFERÊNCIA ACONTECE NESTA LINHA

                AtualizarSaldo(contaDebito);
                AtualizarSaldo(contaCredito);

                Logger.LogInfo("Transferência realizada com sucesso.");
            }
            catch (SqlException ex) //EXCEÇÕES ESPECÍFICAS PRIMEIRO
            {
                transaction.Rollback(); //DESFAZ A TRANSAÇÃO

                Logger.LogErro(ex.ToString());

                throw;
            }
            catch (Exception ex) //EXCEÇÕES MAIS GENÉRICAS DEPOIS
            {
                Logger.LogErro(ex.ToString());

                throw;
            }
            finally
            {
                //LIBERA OS RECURSOS
                comandoTransferencia.Dispose();
                comandoTaxa.Dispose();
                transaction.Dispose();
                connection.Dispose();
            }

            Logger.LogInfo("Saindo do método Efetuar.");
        }

        private ContaCorrente6 AtualizarSaldo(ContaCorrente6 conta)
        {
            SqlCommand comandoSaldo = new SqlCommand("SELECT SALDO_DISPONIVEL FROM CONTA WHERE CONTA_ID = @CONTA_ID", connection);
            comandoSaldo.Parameters.AddWithValue("@CONTA_ID", conta.Id);

            object obj = comandoSaldo.ExecuteScalar();
            decimal novoSaldo = (decimal)(double?)obj;

            conta.AtualizarSaldo(novoSaldo);

            return conta;
        }

        private SqlCommand GetTransferenciaCommand(int contaDebitoId, int contaCreditoId, decimal valorTransferencia)
        {
            SqlCommand command = new SqlCommand("p_TRANSFERENCIA_BANCARIA_i", connection, transaction);

            command.Parameters.AddWithValue("@CONTA_ID_DEBITO", contaDebitoId);
            command.Parameters.AddWithValue("@CONTA_ID_CREDITO", contaCreditoId);
            command.Parameters.AddWithValue("@VALOR", valorTransferencia);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }

        private SqlCommand GetTaxaTransferenciaCommand(int contaId, decimal valorTransferencia)
        {
            SqlCommand command = new SqlCommand("p_TARIFA_TRANSFERENCIA_i", connection, transaction);

            command.Parameters.AddWithValue("@CONTA_ID", contaId);
            command.Parameters.AddWithValue("@VALOR", valorTransferencia);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }

    internal class Logger6
    {
        public static void LogInfo(string mensagem)
        {
            Log(mensagem, "INFO");
        }

        public static void LogErro(string mensagem)
        {
            Log(mensagem, "ERRO");
        }

        private static void Log(string mensagem, string tipo)
        {
            Console.WriteLine(mensagem);

            using (var sw = new StreamWriter("logs.txt", append: true))
            {
                sw.WriteLine(DateTime.Now.ToLocalTime() + ": " + tipo + " - " + mensagem);
            }
        }
    }

    [Serializable]
    public class SaldoInsuficienteException6 : Exception
    {
        public SaldoInsuficienteException6()
        {
        }

        public SaldoInsuficienteException6(string message) : base(message)
        {
        }

        public SaldoInsuficienteException6(string message, Exception inner) : base(message, inner)
        {
        }

        protected SaldoInsuficienteException6(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public override string Message => "Saldo insuficiente.";
    }
}