using Google.Cloud.BigQuery.V2;
using System;

namespace _04_XX_Primeiros_Acessos
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //CursoBQCSharp001();
            CursoBQCSharp002();
        }

        // Acesso ao projeto do BigQuery
        private static void CursoBQCSharp001()
        {
            string projetoId = "nome-do-projeto";
            var cliente = BigQueryClient.Create(projetoId);

            Console.WriteLine("Conexão ao projeto " + projetoId + " realizado com sucesso.");
            Console.ReadLine();
        }

        // Consultando dados de uma tabela
        private static void CursoBQCSharp002()
        {
            string projetoId = "nome-do-projeto";
            var cliente = BigQueryClient.Create(projetoId);

            Console.WriteLine("Conexão ao projeto " + projetoId + " realizado com sucesso.");

            string consultaSQL = "SELECT * FROM NOME-DO-PROJETO.CONJUNTO-DE-DADOS.TABELA;";

            cliente.ExecuteQuery(consultaSQL, null);

            Console.WriteLine("Consulta efetuada com sucesso.");
            Console.ReadLine();
        }
    }
}