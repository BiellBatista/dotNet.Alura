using Google.Cloud.BigQuery.V2;
using System;

namespace _04_XX_Primeiros_Acessos
{
    public class Program
    {
        private static void Main(string[] args)
        {
            CursoBQCSharp001();
        }

        // Acesso ao projeto do BigQuery
        private static void CursoBQCSharp001()
        {
            string projetoId = "nome-do-projeto";
            var cliente = BigQueryClient.Create(projetoId);

            Console.WriteLine("Conexão ao projeto " + projetoId + " realizado com sucesso.");
            Console.ReadLine();
        }
    }
}