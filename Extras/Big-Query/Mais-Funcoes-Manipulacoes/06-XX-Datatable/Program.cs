using _06_XX_Datatable.Classe;
using Google.Apis.Bigquery.v2.Data;
using Google.Cloud.BigQuery.V2;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace _06_XX_Datatable
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
            //CursoBQCSharp010();
            //CursoBQCSharp011();
            //CursoBQCSharp012();
            //CursoBQCSharp013();
            //CursoBQCSharp014();
            //CursoBQCSharp015();
            //CursoBQCSharp016();
            //CursoBQCSharp017();
            //CursoBQCSharp018();
            //CursoBQCSharp019();
            //CursoBQCSharp020();
            //CursoBQCSharp021();
            //CursoBQCSharp022();
            CursoBQCSharp023();
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

        // Inserindo dado com o StreamingBuffer
        private static void CursoBQCSharp011()
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

                object[,] linha = new object[,]
                {
                    {"ID_FABRICA", 1 },
                    {"COD_FABRICA", "001"},
                    {"DESC_FABRICA", "Fábrica do Rio de Janeiro"}
                };

                googleBigQueryClass.IncluirLinhaStreamTable(linha);

                linha = new object[,]
                {
                    {"ID_FABRICA", 2 },
                    {"COD_FABRICA", "002"},
                    {"DESC_FABRICA", "Fábrica de São Paulo"}
                };

                googleBigQueryClass.IncluirLinhaStreamTable(linha);

                Console.WriteLine("Linhas incluidas na tabela {0} com sucesso.", tableId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}.", e.Message);
            }
        }

        // Inserindo vários dados com o StreamingBuffer
        private static void CursoBQCSharp012()
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

                object[,,] linhas = new object[,,]
                {
                   { {"ID_FABRICA", 3 }, {"COD_FABRICA", "003"}, {"DESC_FABRICA", "Fábrica de Minas Gerais"} },
                   { {"ID_FABRICA", 4 }, {"COD_FABRICA", "004"}, {"DESC_FABRICA", "Fábrica de Santa Catarina"} },
                   { {"ID_FABRICA", 5 }, {"COD_FABRICA", "005"}, {"DESC_FABRICA", "Fábrica do Rio Grande do Sul"} }
                };

                googleBigQueryClass.IncluirLinhasStreamTable(linhas);

                Console.WriteLine("Linhas incluidas na tabela {0} com sucesso.", tableId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}.", e.Message);
            }
        }

        // Pegando a data e a hora do StreamBuffer
        private static void CursoBQCSharp013()
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

                object[,,] linhas = new object[,,]
                {
                   { {"ID_FABRICA", 6 }, {"COD_FABRICA", "006"}, {"DESC_FABRICA", "Fábrica do Mato Grosso"} },
                   { {"ID_FABRICA", 7 }, {"COD_FABRICA", "007"}, {"DESC_FABRICA", "Fábrica do Mato Grosso do Sul"} },
                   { {"ID_FABRICA", 8 }, {"COD_FABRICA", "008"}, {"DESC_FABRICA", "Fábrica do Pará"} }
                };

                googleBigQueryClass.IncluirLinhasStreamTable(linhas);

                Console.WriteLine("Linhas incluidas na tabela {0} com sucesso.", tableId);

                string x = googleBigQueryClass.GetStreamingBufferTime();

                Console.WriteLine("Streaming Buffer time é igual a {0}.", x.ToString());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}.", e.Message);
            }
        }

        // Inserindo linha com SQL
        private static void CursoBQCSharp014()
        {
            try
            {
                string projetoId = "nome-do-projeto";

                GoogleBigQueryClass googleBigQueryClass = new GoogleBigQueryClass(projetoId);

                Console.WriteLine("Conexão ao projeto {0} realizado com sucesso.", googleBigQueryClass.ProjetoId);

                string consultaSQL = "INSERT INTO `curso-big-query-09652.Suco_de_Frutas_C_Sharp.FABRICA` VALUES (1, '001', 'Fábrica de Rio de Janeiro');";
                googleBigQueryClass.SQLCommand(consultaSQL);

                consultaSQL = "INSERT INTO `curso-big-query-09652.Suco_de_Frutas_C_Sharp.FABRICA` VALUES (2, '002', 'Fábrica de São Paulo');";
                googleBigQueryClass.SQLCommand(consultaSQL);

                consultaSQL = "INSERT INTO `curso-big-query-09652.Suco_de_Frutas_C_Sharp.FABRICA` VALUES (3, '003', 'Fábrica de Minas Gerais');";
                googleBigQueryClass.SQLCommand(consultaSQL);

                Console.WriteLine("Comando efetuado com sucesso.");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}.", e.Message);
            }
        }

        // Verificando as estatísticas do BigQuery
        private static void CursoBQCSharp015()
        {
            try
            {
                string projetoId = "nome-do-projeto";

                GoogleBigQueryClass googleBigQueryClass = new GoogleBigQueryClass(projetoId);

                Console.WriteLine("Conexão ao projeto {0} realizado com sucesso.", googleBigQueryClass.ProjetoId);

                string consultaSQL = "INSERT INTO `curso-big-query-09652.Suco_de_Frutas_C_Sharp.FABRICA` VALUES (1, '001', 'Fábrica de Rio de Janeiro');";
                googleBigQueryClass.SQLCommand(consultaSQL);

                var dataCriacao = googleBigQueryClass.UnixTimeStampToDateTime(Convert.ToDouble(googleBigQueryClass.Stats.CreationTime / 1000)).ToString();
                var dataFinalizacao = googleBigQueryClass.UnixTimeStampToDateTime(Convert.ToDouble(googleBigQueryClass.Stats.EndTime / 1000)).ToString();
                var numeroBytes = googleBigQueryClass.Stats.TotalBytesProcessed.ToString();

                Console.WriteLine("Data da criação do JOB: {0}.", dataCriacao);
                Console.WriteLine("Data da finalziação do JOB: {0}.", dataFinalizacao);
                Console.WriteLine("Número bytes processados: {0}.", numeroBytes);

                consultaSQL = "INSERT INTO `curso-big-query-09652.Suco_de_Frutas_C_Sharp.FABRICA` VALUES (2, '002', 'Fábrica de São Paulo');";
                googleBigQueryClass.SQLCommand(consultaSQL);

                dataCriacao = googleBigQueryClass.UnixTimeStampToDateTime(Convert.ToDouble(googleBigQueryClass.Stats.CreationTime / 1000)).ToString();
                dataFinalizacao = googleBigQueryClass.UnixTimeStampToDateTime(Convert.ToDouble(googleBigQueryClass.Stats.EndTime / 1000)).ToString();
                numeroBytes = googleBigQueryClass.Stats.TotalBytesProcessed.ToString();

                Console.WriteLine("Data da criação do JOB: {0}.", dataCriacao);
                Console.WriteLine("Data da finalziação do JOB: {0}.", dataFinalizacao);
                Console.WriteLine("Número bytes processados: {0}.", numeroBytes);

                consultaSQL = "INSERT INTO `curso-big-query-09652.Suco_de_Frutas_C_Sharp.FABRICA` VALUES (3, '003', 'Fábrica de Minas Gerais');";
                googleBigQueryClass.SQLCommand(consultaSQL);

                dataCriacao = googleBigQueryClass.UnixTimeStampToDateTime(Convert.ToDouble(googleBigQueryClass.Stats.CreationTime / 1000)).ToString();
                dataFinalizacao = googleBigQueryClass.UnixTimeStampToDateTime(Convert.ToDouble(googleBigQueryClass.Stats.EndTime / 1000)).ToString();
                numeroBytes = googleBigQueryClass.Stats.TotalBytesProcessed.ToString();

                Console.WriteLine("Data da criação do JOB: {0}.", dataCriacao);
                Console.WriteLine("Data da finalziação do JOB: {0}.", dataFinalizacao);
                Console.WriteLine("Número bytes processados: {0}.", numeroBytes);

                Console.WriteLine("Comando efetuado com sucesso.");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}.", e.Message);
            }
        }

        // Alterando dados da tabela
        private static void CursoBQCSharp016()
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

                string consultaSQL = "UPDATE " + googleBigQueryClass.TableName + " SET DESC_FABRICA = 'Fábrica do RJ' WHERE ID_FABRICA = 1;";

                googleBigQueryClass.SQLCommand(consultaSQL);

                var dataCriacao = googleBigQueryClass.UnixTimeStampToDateTime(Convert.ToDouble(googleBigQueryClass.Stats.CreationTime / 1000)).ToString();
                var dataFinalizacao = googleBigQueryClass.UnixTimeStampToDateTime(Convert.ToDouble(googleBigQueryClass.Stats.EndTime / 1000)).ToString();
                var numeroBytes = googleBigQueryClass.Stats.TotalBytesProcessed.ToString();

                Console.WriteLine("Data da criação do JOB: {0}.", dataCriacao);
                Console.WriteLine("Data da finalziação do JOB: {0}.", dataFinalizacao);
                Console.WriteLine("Número bytes processados: {0}.", numeroBytes);

                Console.WriteLine("Comando efetuado com sucesso.");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}.", e.Message);
            }
        }

        // Criando uma nova tabela
        private static void CursoBQCSharp017()
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

                string[,] fields = new string[,]
                {
                    {"ID_CLIENTE", "Campo Identificador do Cliente", "INTEGER", "NULLABLE" },
                    {"COD_CLIENTE", "Código do Cliente", "STRING", "NULLABLE" },
                    {"DESC_CLIENTE", "Descritor do Cliente", "STRING", "NULLABLE" },
                    {"COD_CIDADE", "Cidade do Cliente", "STRING", "NULLABLE" },
                    {"DESC_CIDADE", "Descritor da Cidade do Cliente", "STRING", "NULLABLE" },
                    {"COD_ESTADO", "Estado do Cliente", "STRING", "NULLABLE" },
                    {"DESC_ESTADO", "Descritor do Estado do Cliente", "STRING", "NULLABLE" },
                    {"COD_REGIAO", "Região do Cliente", "STRING","NULLABLE" },
                    {"DESC_REGIAO", "Descritor da Região do Cliente", "STRING", "NULLABLE" },
                    {"COD_SEGMENTO", "Segmento do Cliente", "STRING", "NULLABLE" },
                    {"DESC_SEGMENTO", "Descritor do Segmento do Cliente", "STRING", "NULLABLE" }
                };

                googleBigQueryClass.CriarTabela(tableId, fields);

                Console.WriteLine("Tabela {0} criada com sucesso.", tableId);

                Console.WriteLine("Comando efetuado com sucesso.");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}.", e.Message);
            }
        }

        // Lendo um CSV
        private static void CursoBQCSharp018()
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

                Console.WriteLine("Conexão com a Tabela {0} feita com sucesso.", tableId);

                using (StreamReader sr = new StreamReader("C:\\CursoBQCSharp\\CursoBQCSharp\\CSV\\cliente.csv"))
                {
                    string linhaCabecario;
                    string linha;

                    linhaCabecario = sr.ReadLine();

                    string[] vetLinhaCabecario = linhaCabecario.Split(',');

                    while ((linha = sr.ReadLine()) != null)
                    {
                        string[] vetLinha = linha.Split(',');
                        string consultaSQL;

                        consultaSQL = " INSERT INTO " + googleBigQueryClass.TableName + " ";
                        consultaSQL += $" ({vetLinhaCabecario[0]}, ";
                        consultaSQL += $" {vetLinhaCabecario[1]}, ";
                        consultaSQL += $" {vetLinhaCabecario[2]}, ";
                        consultaSQL += $" {vetLinhaCabecario[3]}, ";
                        consultaSQL += $" {vetLinhaCabecario[4]}, ";
                        consultaSQL += $" {vetLinhaCabecario[5]}, ";
                        consultaSQL += $" {vetLinhaCabecario[6]}, ";
                        consultaSQL += $" {vetLinhaCabecario[7]}, ";
                        consultaSQL += $" {vetLinhaCabecario[8]}, ";
                        consultaSQL += $" {vetLinhaCabecario[9]}, ";
                        consultaSQL += $" {vetLinhaCabecario[10]}) ";
                        consultaSQL += " VALUES ";
                        consultaSQL += $" ({vetLinha[0]}, ";
                        consultaSQL += $" '{vetLinha[1]}', ";
                        consultaSQL += $" '{vetLinha[2]}', ";
                        consultaSQL += $" '{vetLinha[3]}', ";
                        consultaSQL += $" '{vetLinha[4]}', ";
                        consultaSQL += $" '{vetLinha[5]}', ";
                        consultaSQL += $" '{vetLinha[6]}', ";
                        consultaSQL += $" '{vetLinha[7]}', ";
                        consultaSQL += $" '{vetLinha[8]}', ";
                        consultaSQL += $" '{vetLinha[9]}', ";
                        consultaSQL += $" '{vetLinha[10]}'); ";

                        googleBigQueryClass.SQLCommand(consultaSQL);

                        Console.WriteLine("Foi incluido dados do cliente {0}.", vetLinha[2]);
                    }
                }

                Console.WriteLine("Comando efetuado com sucesso.");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}.", e.Message);
            }
        }

        // Lendo um CSV
        private static void CursoBQCSharp019()
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

                Console.WriteLine("Conexão com a Tabela {0} feita com sucesso.", tableId);

                using (StreamReader sr = new StreamReader("C:\\CursoBQCSharp\\CursoBQCSharp\\CSV\\cliente.csv"))
                {
                    string linhaCabecario;
                    string linha;

                    linhaCabecario = sr.ReadLine();

                    string[] vetLinhaCabecario = linhaCabecario.Split(',');

                    while ((linha = sr.ReadLine()) != null)
                    {
                        string[] vetLinha = linha.Split(',');
                        List<BigQueryParameter> listParam = new List<BigQueryParameter>();

                        listParam.Add(new BigQueryParameter(vetLinhaCabecario[0], BigQueryDbType.Int64, vetLinha[0]));
                        listParam.Add(new BigQueryParameter(vetLinhaCabecario[1], BigQueryDbType.String, vetLinha[1]));
                        listParam.Add(new BigQueryParameter(vetLinhaCabecario[2], BigQueryDbType.String, vetLinha[2]));
                        listParam.Add(new BigQueryParameter(vetLinhaCabecario[3], BigQueryDbType.String, vetLinha[3]));
                        listParam.Add(new BigQueryParameter(vetLinhaCabecario[4], BigQueryDbType.String, vetLinha[4]));
                        listParam.Add(new BigQueryParameter(vetLinhaCabecario[5], BigQueryDbType.String, vetLinha[5]));
                        listParam.Add(new BigQueryParameter(vetLinhaCabecario[6], BigQueryDbType.String, vetLinha[6]));
                        listParam.Add(new BigQueryParameter(vetLinhaCabecario[7], BigQueryDbType.String, vetLinha[7]));
                        listParam.Add(new BigQueryParameter(vetLinhaCabecario[8], BigQueryDbType.String, vetLinha[8]));
                        listParam.Add(new BigQueryParameter(vetLinhaCabecario[9], BigQueryDbType.String, vetLinha[9]));
                        listParam.Add(new BigQueryParameter(vetLinhaCabecario[10], BigQueryDbType.String, vetLinha[10]));

                        string consultaSQL;

                        consultaSQL = @"INSERT INTO " + googleBigQueryClass.TableName + " VALUES ";
                        consultaSQL += $"(@{vetLinhaCabecario[0]},";
                        consultaSQL += $"@{vetLinhaCabecario[1]},";
                        consultaSQL += $"@{vetLinhaCabecario[2]},";
                        consultaSQL += $"@{vetLinhaCabecario[3]},";
                        consultaSQL += $"@{vetLinhaCabecario[4]},";
                        consultaSQL += $"@{vetLinhaCabecario[5]},";
                        consultaSQL += $"@{vetLinhaCabecario[6]},";
                        consultaSQL += $"@{vetLinhaCabecario[7]},";
                        consultaSQL += $"@{vetLinhaCabecario[8]},";
                        consultaSQL += $"@{vetLinhaCabecario[9]},";
                        consultaSQL += $"@{vetLinhaCabecario[10]}); ";

                        //googleBigQueryClass.SQLCommandParam(consultaSQL, listParam.ToArray());

                        Console.WriteLine("Foi incluido dados do cliente {0}.", vetLinha[2]);
                    }
                }

                Console.WriteLine("Comando efetuado com sucesso.");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}.", e.Message);
            }
        }

        // Lendo um CSV
        private static void CursoBQCSharp020()
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

                // O array multidimensional que representa o esquema tem que ter os campos declarados na mesma ordem que as colunas do CSV.
                string[,] fields = new string[,]
                {
                    {"ID_PRODUTO", "Campo Identificador do Produto", "INTEGER", "NULLABLE"},
                    {"COD_PRODUTO", "Campo com o código do Produto", "STRING", "NULLABLE"},
                    {"DESC_PRODUTO", "Descritor do Produto", "STRING", "NULLABLE"},
                    {"COD_MARCA", "Campo com o código da marca", "STRING", "NULLABLE"},
                    {"DESC_MARCA", "Descritor da marca", "STRING", "NULLABLE"},
                    {"COD_SEGMENTO", "Campo com o código do segmento", "STRING", "NULLABLE"},
                    {"DESC_SEGMENTO", "Descritor do segmento", "STRING", "NULLABLE"},
                    {"ATR_TAMANHO", "Tamanho da embalagem", "STRING", "NULLABLE"},
                    {"ATR_SABOR", "Sabor do produto", "STRING", "NULLABLE"}
                };

                googleBigQueryClass.AbrirTabela(tableId);

                Console.WriteLine("Tabela {0} aberta com sucesso.", tableId);

                googleBigQueryClass.LoadCSV("C:\\CursoBQCSharp\\CursoBQCSharp\\CSV\\produto.csv", fields);

                Console.WriteLine("Leitura efetuada com sucesso.");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}.", e.Message);
            }
        }

        // Consultando dados de uma tabela através de SQL
        private static void CursoBQCSharp021()
        {
            try
            {
                string projetoId = "nome-do-projeto";
                var cliente = BigQueryClient.Create(projetoId);

                Console.WriteLine("Conexão ao projeto {0} realizado com sucesso.", projetoId);

                string consultaSQL = "SELECT * FROM `curso-big-query-09652.Suco_de_Frutas_C_Sharp.CLIENTE`;";
                var resultadoSQL = cliente.ExecuteQuery(consultaSQL, null);

                foreach (var linha in resultadoSQL)
                {
                    var id = linha["ID_CLIENTE"];
                    var cod = linha["COD_CLIENTE"];
                    var desc = linha["DESC_CLIENTE"];

                    Console.WriteLine($"{id} : {cod} : {desc}");
                }

                Console.WriteLine("Consula efetuada com sucesso.");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}.", e.Message);
            }
        }

        // Consultando dados de uma tabela através de SQL
        private static void CursoBQCSharp022()
        {
            try
            {
                string projetoId = "nome-do-projeto";
                var cliente = BigQueryClient.Create(projetoId);

                Console.WriteLine("Conexão ao projeto {0} realizado com sucesso.", projetoId);

                string consultaSQL = "SELECT * FROM `curso-big-query-09652.Suco_de_Frutas_C_Sharp.CLIENTE`;";
                var resultadoSQL = cliente.ExecuteQuery(consultaSQL, null);

                int i = 0;

                for (i = 0; i <= resultadoSQL.Schema.Fields.Count - 1; i++)
                {
                    var nome = resultadoSQL.Schema.Fields[i].Name;
                    var tipo = resultadoSQL.Schema.Fields[i].Type;

                    Console.WriteLine($"{nome} : {tipo}");
                }

                Console.WriteLine("Consula efetuada com sucesso.");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}.", e.Message);
            }
        }

        // Criando um DataTable
        private static void CursoBQCSharp023()
        {
            try
            {
                string projetoId = "nome-do-projeto";
                var cliente = BigQueryClient.Create(projetoId);

                Console.WriteLine("Conexão ao projeto {0} realizado com sucesso.", projetoId);

                string consultaSQL = "SELECT * FROM `curso-big-query-09652.Suco_de_Frutas_C_Sharp.CLIENTE`;";
                var resultadoSQL = cliente.ExecuteQuery(consultaSQL, null);

                DataTable dt = new DataTable();
                int i = 0;

                for (i = 0; i <= resultadoSQL.Schema.Fields.Count - 1; i++)
                {
                    var vField = resultadoSQL.Schema.Fields[i];

                    if (vField.Type == "STRING")
                    {
                        DataColumn colStr32 = new DataColumn(vField.Name);

                        colStr32.DataType = System.Type.GetType("System.String");
                        dt.Columns.Add(colStr32);
                    }
                    else if (vField.Type == "INTEGER")
                    {
                        DataColumn colInt32 = new DataColumn(vField.Name);

                        colInt32.DataType = System.Type.GetType("System.Int32");
                        dt.Columns.Add(colInt32);
                    }
                }

                Console.WriteLine("Consula efetuada com sucesso.");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: {0}.", e.Message);
            }
        }
    }
}