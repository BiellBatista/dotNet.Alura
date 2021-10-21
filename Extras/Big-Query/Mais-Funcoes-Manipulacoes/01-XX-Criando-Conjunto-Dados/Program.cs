using Google.Cloud.BigQuery.V2;
using System;

namespace _01_XX_Criando_Conjunto_Dados
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //CursoBQCSharp001();
            //CursoBQCSharp002();
            CursoBQCSharp003();
        }

        // Conecatando ao projeto
        private static void CursoBQCSharp001()
        {
            string projetoId = "nome-do-projeto";
            var cliente = BigQueryClient.Create(projetoId);

            Console.WriteLine("Conexão ao projeto {0} realizado com sucesso.", projetoId);
            Console.ReadLine();
        }

        // Criando conjunto de dados
        private static void CursoBQCSharp002()
        {
            try
            {
                string projetoId = "nome-do-projeto";
                var cliente = BigQueryClient.Create(projetoId);

                Console.WriteLine("Conexão ao projeto " + projetoId + " realizado com sucesso.");

                string datasetId = "identificador-conjunto-dados";
                BigQueryDataset dataset = cliente.CreateDataset(datasetId);

                Console.WriteLine("Conjunto de dados {0} criado com sucesso.", datasetId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}.", e.Message);
            }
        }

        // Criando conjunto de dados em uma localização definida
        private static void CursoBQCSharp003()
        {
            try
            {
                string projetoId = "nome-do-projeto";
                var cliente = BigQueryClient.Create(projetoId);

                Console.WriteLine("Conexão ao projeto " + projetoId + " realizado com sucesso.");

                string datasetId = "identificador-conjunto-dados";
                string localizacao = "southamerica-east1";

                CreateDatasetOptions options = new CreateDatasetOptions();

                BigQueryDataset dataset = cliente.CreateDataset(datasetId, null, options);

                Console.WriteLine("Conjunto de dados {0} criado com sucesso.", datasetId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}", e.Message);
            }
        }
    }
}