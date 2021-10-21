using Google.Apis.Bigquery.v2.Data;
using Google.Cloud.BigQuery.V2;
using System.Collections.Generic;

namespace _02_XX_Manipulando_Tabelas.Classe
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
    }
}