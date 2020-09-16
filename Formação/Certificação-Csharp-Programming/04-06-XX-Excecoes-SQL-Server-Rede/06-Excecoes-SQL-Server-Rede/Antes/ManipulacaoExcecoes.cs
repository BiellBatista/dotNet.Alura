using System;
using System.Data.SqlClient;
using System.IO;

namespace _04_06_XX_Excecoes_SQL_Server_Rede.Antes
{
    class ManipulacaoExcecoes6 : IAulaItem
    {
        public void Executar()
        {
            Console.ReadKey();
        }
    }

    class ContaCorrente6
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
            if (Saldo < valor)
            {
                //throw new ArgumentException("saldo insuficiente");
                throw new SaldoInsuficienteException6();
            }

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
    }

    interface ITransferenciaBancaria6
    {
        void Efetuar(ContaCorrente6 contaDebito, ContaCorrente6 contaCredito, decimal valor);
    }

    class TransferenciaBancaria6 : ITransferenciaBancaria6
    {
        public void Efetuar(ContaCorrente6 contaDebito, ContaCorrente6 contaCredito, decimal valor)
        {
            Logger.LogInfo("Entrando do método Efetuar.");

            contaDebito.Debitar(valor);
            contaCredito.Creditar(valor);

            Logger.LogInfo("Transferência realizada com sucesso.");
            Logger.LogInfo("Saindo do método Efetuar.");
        }
    }

    class TransferenciaBancaria_BD6 : ITransferenciaBancaria6
    {
        private const string CONNECTION_STRING = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB\ByteBank.mdf;Integrated Security=True";
        private const decimal TAXA_TRANSFERENCIA = 1.0m;
        private SqlConnection connection;
        private SqlTransaction transaction;

        public void Efetuar(ContaCorrente6 contaCredito, ContaCorrente6 contaDebito, decimal valor)
        {
            Logger.LogInfo("Entrando do método Efetuar.");

            connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            transaction = connection.BeginTransaction();

            SqlCommand comandoTransferencia = GetTransferenciaCommand(contaCredito.Id, contaDebito.Id, valor);
            SqlCommand comandoTaxa = GetTaxaTransferenciaCommand(contaCredito.Id, TAXA_TRANSFERENCIA);

            comandoTaxa.ExecuteNonQuery();
            comandoTransferencia.ExecuteNonQuery();
            transaction.Commit();

            Logger.LogInfo("Transferência realizada com sucesso.");
            Logger.LogInfo("Saindo do método Efetuar.");
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

    [Serializable]
    public class SaldoInsuficienteException6 : Exception
    {
        public SaldoInsuficienteException6() { }
        public SaldoInsuficienteException6(string message) : base(message) { }
        public SaldoInsuficienteException6(string message, Exception inner) : base(message, inner) { }
        protected SaldoInsuficienteException6(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public override string Message => "Saldo Insuficiente.";
    }

    class Logger6
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
            using (var sw = new StreamWriter("logs.txt", append: true))
            {
                sw.WriteLine(DateTime.Now.ToLocalTime() + ": " + tipo + " - " + mensagem);
            }
        }
    }
}
