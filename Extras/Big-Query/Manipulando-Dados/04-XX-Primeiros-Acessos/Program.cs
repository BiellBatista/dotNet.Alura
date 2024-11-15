﻿using Google.Cloud.BigQuery.V2;
using System;

namespace _04_XX_Primeiros_Acessos
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //CursoBQCSharp001();
            //CursoBQCSharp002();
            //CursoBQCSharp003();
            //CursoBQCSharp004A();
            CursoBQCSharp004B();
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

            string consultaSQL = "SELECT * FROM `NOME-DO-PROJETO.CONJUNTO-DE-DADOS.TABELA`;";

            cliente.ExecuteQuery(consultaSQL, null);

            Console.WriteLine("Consulta efetuada com sucesso.");
            Console.ReadLine();
        }

        // Inserido dados em uma tabela
        private static void CursoBQCSharp003()
        {
            string projetoId = "nome-do-projeto";
            var cliente = BigQueryClient.Create(projetoId);

            Console.WriteLine("Conexão ao projeto " + projetoId + " realizado com sucesso.");

            string comandoSQL = "INSERT INTO `NOME-DO-PROJETO.CONJUNTO-DE-DADOS.TABELA` VALUES ();";

            // o ExecuteQuery serve para executar qualquer comando de SQL
            cliente.ExecuteQuery(comandoSQL, null);

            Console.WriteLine("Comando efetuado com sucesso.");
            Console.ReadLine();
        }

        // Atualizando dados em uma tabela
        private static void CursoBQCSharp004A()
        {
            string projetoId = "nome-do-projeto";
            var cliente = BigQueryClient.Create(projetoId);

            Console.WriteLine("Conexão ao projeto " + projetoId + " realizado com sucesso.");

            string comandoSQL = "UPDATE `NOME-DO-PROJETO.CONJUNTO-DE-DADOS.TABELA` SET CAMPO = 'NOVO-VALOR' WHERE ID = X;";

            // o ExecuteQuery serve para executar qualquer comando de SQL
            cliente.ExecuteQuery(comandoSQL, null);

            Console.WriteLine("Comando efetuado com sucesso.");
            Console.ReadLine();
        }

        // Excluindo dados em uma tabela
        private static void CursoBQCSharp004B()
        {
            string projetoId = "nome-do-projeto";
            var cliente = BigQueryClient.Create(projetoId);

            Console.WriteLine("Conexão ao projeto " + projetoId + " realizado com sucesso.");

            string comandoSQL = "DELETE FROM `NOME-DO-PROJETO.CONJUNTO-DE-DADOS.TABELA` WHERE ID = X;";

            // o ExecuteQuery serve para executar qualquer comando de SQL
            cliente.ExecuteQuery(comandoSQL, null);

            Console.WriteLine("Comando efetuado com sucesso.");
            Console.ReadLine();
        }
    }
}