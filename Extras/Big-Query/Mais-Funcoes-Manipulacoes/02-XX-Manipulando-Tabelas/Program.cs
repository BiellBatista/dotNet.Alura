using _02_XX_Manipulando_Tabelas.Classe;
using Google.Apis.Bigquery.v2.Data;
using Google.Cloud.BigQuery.V2;
using System;
using System.Collections.Generic;

namespace _02_XX_Manipulando_Tabelas
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //CursoBQCSharp001();
            //CursoBQCSharp002();
            //CursoBQCSharp003();
            //CursoBQCSharp004();
            //CursoBQCSharp005();
            //CursoBQCSharp006();
            //CursoBQCSharp007();
            //CursoBQCSharp008();
            //CursoBQCSharp009();
            CursoBQCSharp010();
        }

        // Conectando ao projeto
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

        // Conecatando ao projeto com uma nova classe
        private static void CursoBQCSharp004()
        {
            string projetoId = "nome-do-projeto";
            GoogleBigQueryClass googleBigQueryClass = new GoogleBigQueryClass(projetoId);

            Console.WriteLine("Conexão ao projeto {0} realizado com sucesso.", googleBigQueryClass.ProjetoId);
            Console.ReadLine();
        }

        // Conecatando ao projeto com uma nova classe
        private static void CursoBQCSharp005()
        {
            try
            {
                string projetoId = "nome-do-projeto";
                GoogleBigQueryClass googleBigQueryClass = new GoogleBigQueryClass(projetoId);

                Console.WriteLine("Conexão ao projeto {0} realizado com sucesso.", googleBigQueryClass.ProjetoId);

                string datasetId = "identificador-conjunto-dados";
                googleBigQueryClass.CriarConjuntoDados(datasetId);

                Console.WriteLine("Conjunto de dados {0} criado com sucesso.", googleBigQueryClass.DataSetId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}.", e.Message);
            }
        }

        // Criando uma tabela
        private static void CursoBQCSharp006()
        {
            try
            {
                string projetoId = "nome-do-projeto";
                string datasetId = "identificador-conjunto-dados";
                string tableId = "nome-da-tabela";

                var cliente = BigQueryClient.Create(projetoId);

                Console.WriteLine("Conexão ao projeto " + projetoId + " realizado com sucesso.");

                BigQueryDataset dataset = cliente.GetDataset(datasetId);

                Console.WriteLine("Conexão com o conjunto de dados {0} feita com sucesso.", dataset);

                TableSchema schema = new TableSchema();
                TableFieldSchema field = new TableFieldSchema();

                schema.Fields = new List<TableFieldSchema>();

                field.Name = "ID_FABRICA";
                field.Description = "Identificador da Fábrica.";
                field.Type = "INTEGER";
                field.Mode = "NULLABLE";
                schema.Fields.Add(field);

                field = new TableFieldSchema();
                field.Name = "COD_FABRICA";
                field.Description = "Código da Fábrica.";
                field.Type = "STRING";
                field.Mode = "NULLABLE";
                schema.Fields.Add(field);

                field = new TableFieldSchema();
                field.Name = "DESC_FABRICA";
                field.Description = "Descritor da Fábrica.";
                field.Type = "STRING";
                field.Mode = "NULLABLE";
                schema.Fields.Add(field);

                dataset.CreateTable(tableId, schema);

                Console.WriteLine("Tabela {0} criada com sucesso.", tableId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}.", e.Message);
            }
        }

        // Criando uma tabela
        private static void CursoBQCSharp007()
        {
            try
            {
                string projetoId = "nome-do-projeto";
                string datasetId = "identificador-conjunto-dados";
                string tableId = "nome-da-tabela";

                var cliente = BigQueryClient.Create(projetoId);

                Console.WriteLine("Conexão ao projeto " + projetoId + " realizado com sucesso.");

                BigQueryDataset dataset = cliente.GetDataset(datasetId);

                Console.WriteLine("Conexão com o conjunto de dados {0} feita com sucesso.", dataset);

                TableSchema schema = new TableSchema();

                schema.Fields = new List<TableFieldSchema>();
                string[,] fields = new string[,]
                {
                    {"ID_FABRICA","Identificador da Fábrica", "INTEGER","NULLABLE" },
                    {"COD_FABRICA","Código da Fábrica", "STRING","NULLABLE" },
                    {"DESC_FABRICA","Descritor da Fábrica", "STRING","NULLABLE" }
                };

                for (int i = 0; i < fields.GetLength(0); i++)
                {
                    TableFieldSchema field = new TableFieldSchema();

                    field.Name = fields[i, 0];
                    field.Description = fields[i, 1];
                    field.Type = fields[i, 2];
                    field.Mode = fields[i, 3];

                    schema.Fields.Add(field);
                }

                dataset.CreateTable(tableId, schema);

                Console.WriteLine("Tabela {0} criada com sucesso.", tableId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}.", e.Message);
            }
        }

        // Criando uma tabela com outra classe
        private static void CursoBQCSharp008()
        {
            try
            {
                string projetoId = "nome-do-projeto";
                GoogleBigQueryClass googleBigQueryClass = new GoogleBigQueryClass(projetoId);

                Console.WriteLine("Conexão ao projeto {0} realizado com sucesso.", googleBigQueryClass.ProjetoId);

                string datasetId = "identificador-conjunto-dados";
                googleBigQueryClass.AbrirConjuntoDados(datasetId);

                Console.WriteLine("Conexão com o conjunto de dados {0} feita com sucesso.", googleBigQueryClass.DataSetId);

                string[,] fields = new string[,]
                {
                    {"ID_FABRICA","Identificador da Fábrica", "INTEGER","NULLABLE" },
                    {"COD_FABRICA","Código da Fábrica", "STRING","NULLABLE" },
                    {"DESC_FABRICA","Descritor da Fábrica", "STRING","NULLABLE" }
                };

                string tableId = "nome-da-tabela";
                googleBigQueryClass.CriarTabela(tableId, fields);

                Console.WriteLine("Tabela {0} criada com sucesso.", tableId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}.", e.Message);
            }
        }

        // Apagando a tabela
        private static void CursoBQCSharp009()
        {
            try
            {
                string projetoId = "nome-do-projeto";
                string tableId = "nome-da-tabela";
                string datasetId = "identificador-conjunto-dados";

                var cliente = BigQueryClient.Create(projetoId);

                Console.WriteLine("Conexão ao projeto {0} realizado com sucesso.", projetoId);

                BigQueryTable tabela = cliente.GetTable(datasetId, tableId);

                tabela.Delete();

                Console.WriteLine("Tabela {0} foi apagada com sucesso.", tableId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}.", e.Message);
            }
        }

        // Apagando a tabela com outra clase
        private static void CursoBQCSharp010()
        {
            try
            {
                string projetoId = "nome-do-projeto";
                string datasetId = "identificador-conjunto-dados";
                string tableId = "nome-da-tabela";

                GoogleBigQueryClass googleBigQueryClass = new GoogleBigQueryClass(projetoId);

                Console.WriteLine("Conexão ao projeto {0} realizado com sucesso.", googleBigQueryClass.ProjetoId);

                googleBigQueryClass.AbrirConjuntoDados(datasetId);

                Console.WriteLine("Conexão com o conjunto de dados {0} feita com sucesso.", googleBigQueryClass.DataSetId);

                googleBigQueryClass.AbrirTabela(tableId);

                Console.WriteLine("Conexão com a tabela {0} feita com sucesso.", tableId);

                googleBigQueryClass.ApagarTabela();

                Console.WriteLine("Tabela {0} apagada com sucesso.", tableId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}.", e.Message);
            }
        }
    }
}