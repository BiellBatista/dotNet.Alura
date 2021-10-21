using Google.Apis.Bigquery.v2.Data;
using Google.Cloud.BigQuery.V2;
using System;
using System.Collections.Generic;

namespace _04_XX_Usando_SQL_Classe.Classe
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
    }
}