using Google.Apis.Bigquery.v2.Data;
using Google.Cloud.BigQuery.V2;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace _05_XX_Lendo_CSV.Classe
{
    public class GoogleBigQueryClass
    {
        public string ProjetoId { get; set; }
        public string DataSetId { get; set; }
        public string TableId { get; set; }
        public string TableName { get; set; }

        public BigQueryClient Cliente { get; set; }
        public BigQueryDataset DataSet { get; set; }
        public BigQueryTable Tabela { get; set; }
        public BigQueryResults Resultado { get; set; }
        public JobStatistics Stats { get; set; }
        public DataTable DataTable { get; set; }

        public GoogleBigQueryClass(string projetoId)
        {
            ProjetoId = projetoId;

            Cliente = BigQueryClient.Create(ProjetoId);
        }

        public void CriarConjuntoDados(string dataSetId)
        {
            DataSetId = dataSetId;
            DataSet = Cliente.CreateDataset(DataSetId);
        }

        public void AbrirConjuntoDados(string dataSetId)
        {
            DataSetId = dataSetId;
            DataSet = Cliente.GetDataset(DataSetId);
        }

        public void CriarTabela(string tableId, string[,] fields)
        {
            TableSchema schema = new TableSchema();
            schema.Fields = new List<TableFieldSchema>();

            for (int i = 0; i < fields.GetLength(0); i++)
            {
                TableFieldSchema field = new TableFieldSchema();

                field.Name = fields[i, 0];
                field.Description = fields[i, 1];
                field.Type = fields[i, 2];
                field.Mode = fields[i, 3];

                schema.Fields.Add(field);
            }

            DataSet.CreateTable(tableId, schema);
        }

        public void AbrirTabela(string tableId)
        {
            TableId = tableId;
            TableName = "`" + ProjetoId + "." + DataSetId + "." + TableId + "`";

            Tabela = Cliente.GetTable(DataSetId, TableId);
        }

        public void ApagarTabela()
        {
            Tabela.Delete();
        }

        public void IncluirLinhaStreamTable(object[,] linha)
        {
            BigQueryInsertRow row = new BigQueryInsertRow();

            for (int i = 0; i < linha.GetLength(0); i++)
                row.Add((string)linha[i, 0], linha[i, 1]);

            row.InsertId = Guid.NewGuid().ToString();

            List<BigQueryInsertRow> rows = new List<BigQueryInsertRow>();

            rows.Add(row);

            Cliente.InsertRows(DataSetId, TableId, rows);
        }

        public void IncluirLinhasStreamTable(object[,,] linha)
        {
            List<BigQueryInsertRow> rows = new List<BigQueryInsertRow>();

            for (int i = 0; i < linha.GetLength(0); i++)
            {
                BigQueryInsertRow row = new BigQueryInsertRow();

                for (int j = 0; j < linha.GetLength(0); j++)
                    row.Add((string)linha[i, j, 0], linha[i, j, 1]);

                row.InsertId = System.Guid.NewGuid().ToString();

                rows.Add(row);
            }

            Cliente.InsertRows(DataSetId, TableId, rows);
        }

        public string GetStreamingBufferTime()
        {
            var x = Convert.ToDouble(Tabela.Resource.StreamingBuffer.OldestEntryTime);
            var x2 = x / 1000 + (60 * 60 * 1.5);
            var k = UnixTimeStampToDateTime(x2).ToString();

            return k;
        }

        public DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();

            return dtDateTime;
        }

        public void SQLCommand(string sql)
        {
            Resultado = Cliente.ExecuteQuery(sql, null);

            // Verificando as estatísticas do BigQuery
            var job = Cliente.GetJob(Resultado.JobReference);

            Stats = job.Statistics;
        }

        public void SQLCommandParam(string sql, string[,] param)
        {
            int i = 0;

            List<BigQueryParameter> listParam = new List<BigQueryParameter>();

            for (i = 0; i < param.GetLength(0); i++)
            {
                if (param[i, 1] == "STRING")
                    listParam.Add(new BigQueryParameter(param[i, 0], BigQueryDbType.String, param[i, 2]));
                else if (param[i, 1] == "INTEGER")
                    listParam.Add(new BigQueryParameter(param[i, 0], BigQueryDbType.Int64, param[i, 2]));
            }

            Resultado = Cliente.ExecuteQuery(sql, listParam.ToArray());

            var job = Cliente.GetJob(Resultado.JobReference);

            Stats = job.Statistics;
        }

        public void SQLCommandParamDt(string sql, string[,] param)
        {
            int i = 0;

            List<BigQueryParameter> listParam = new List<BigQueryParameter>();

            for (i = 0; i < param.GetLength(0); i++)
            {
                if (param[i, 1] == "STRING")
                    listParam.Add(new BigQueryParameter(param[i, 0], BigQueryDbType.String, param[i, 2]));
                else if (param[i, 1] == "INTEGER")
                    listParam.Add(new BigQueryParameter(param[i, 0], BigQueryDbType.Int64, param[i, 2]));
            }

            DataTable = new DataTable();
            Resultado = Cliente.ExecuteQuery(sql, listParam.ToArray());

            var job = Cliente.GetJob(Resultado.JobReference);
            Stats = job.Statistics;

            for (i = 0; i <= Resultado.Schema.Fields.Count - 1; i++)
            {
                var vField = Resultado.Schema.Fields[i];

                if (vField.Type == "STRING")
                {
                    DataColumn colStr32 = new DataColumn(vField.Name);
                    colStr32.DataType = System.Type.GetType("System.String");
                    DataTable.Columns.Add(colStr32);
                }
                else if (vField.Type == "INTEGER")
                {
                    DataColumn colInt32 = new DataColumn(vField.Name);
                    colInt32.DataType = System.Type.GetType("System.Int32");
                    DataTable.Columns.Add(colInt32);
                }
            }

            foreach (var linha in Resultado)
            {
                DataRow dr = DataTable.NewRow();

                for (i = 0; i <= Resultado.Schema.Fields.Count - 1; i++)
                    dr[i] = linha[i];

                DataTable.Rows.Add(dr);
            }
        }

        public void LoadCSV(string arquivo, string[,] fields)
        {
            TableSchema schema = new TableSchema();

            schema.Fields = new List<TableFieldSchema>();

            for (int i = 0; i < fields.GetLength(0); i++)
            {
                TableFieldSchema field = new TableFieldSchema();

                field.Name = fields[i, 0];
                field.Description = fields[i, 1];
                field.Type = fields[i, 2];
                field.Mode = fields[i, 3];

                schema.Fields.Add(field);
            }

            var uploadCsvOptions = new UploadCsvOptions()
            {
                SkipLeadingRows = 1,
                FieldDelimiter = ","
            };

            using (FileStream stream = File.Open(arquivo, FileMode.Open))
            {
                BigQueryJob job = Cliente.UploadCsv(DataSetId, TableId, schema, stream, uploadCsvOptions);

                job.PollUntilCompleted();
            }
        }
    }
}