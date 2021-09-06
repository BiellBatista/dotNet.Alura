using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace _08_06_XX_Lendo_Atualizando_Banco_Dados.Depois
{
    public class LendoAtualizandoBancoDados01 : IAulaItem //Ler Dados com SQL
    {
        private const string DatabaseServer = @"(localdb)\MSSQLLocalDB";
        private const string MasterDatabase = "master";
        private const string DatabaseName = "Cinema";

        public void Executar()
        {
            CriarBancoDeDadosAsync().Wait();

            //TAREFAS:
            //1. ABRIR UMA CONEXÃO COM O BANCO DE DADOS
            //2. CRIAR UMA CONSULTA PARA TRAZER DIRETOR E TÍTULO DO FILME
            //3. LER E EXIBIR OS RESULTADOS DA CONSULTA

            const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cinema;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (var conexao = new SqlConnection(ConnectionString))
            {
                conexao.OpenAsync().Wait();

                using (var comando =
                    new SqlCommand(@"SELECT d.Nome AS Diretor, f.Titulo AS Titulo
                                FROM Filmes AS f
                                INNER JOIN Diretores AS d
                                    ON d.Id = f.DiretorId", conexao))
                {
                    var leitor = comando.ExecuteReaderAsync().Result;

                    while (leitor.ReadAsync().Result)
                    {
                        var diretor = leitor["Diretor"];
                        var titulo = leitor["Titulo"];

                        Console.WriteLine($"Diretor: {diretor} - Título: {titulo}");
                    }
                }
            }

            Console.ReadKey();
        }

        #region Banco de dados

        private async Task CriarBancoDeDadosAsync()
        {
            await CriarBancoAsync();
            await CriarTabelasAsync();
            await InserirRegistrosAsync();
        }

        private async Task CriarBancoAsync()
        {
            string sql = $@"IF EXISTS (SELECT * FROM sys.databases WHERE name = N'{DatabaseName}')
                    BEGIN
                        DROP DATABASE [{DatabaseName}]
                    END;
                    CREATE DATABASE [{DatabaseName}];";

            await ExecutarComandoAsync(sql, MasterDatabase);
        }

        private async Task CriarTabelasAsync()
        {
            string sql = $@"CREATE TABLE [dbo].[Diretores] (
                        [Id]   INT           IDENTITY (1, 1) NOT NULL,
                        [Nome] VARCHAR (255) NOT NULL
                    );
                    CREATE TABLE [dbo].[Filmes] (
                        [Id]        INT           IDENTITY (1, 1) NOT NULL,
                        [DiretorId] INT           NOT NULL,
                        [Titulo]    VARCHAR (255) NOT NULL,
                        [Ano]       INT           NOT NULL,
                        [Minutos]   INT           NOT NULL
                    );";

            await ExecutarComandoAsync(sql, DatabaseName);
        }

        private async Task InserirRegistrosAsync()
        {
            string sql = @"
                    INSERT Diretores (Nome) VALUES ('Quentin Tarantino');
                    INSERT Diretores (Nome) VALUES ('James Cameron');
                    INSERT Diretores (Nome) VALUES ('Tim Burton');

                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (1, 'Pulp Fiction', 1994,	154);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (1, 'Django Livre', 2012,	165);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (1, 'Kill Bill Volume 1', 2003,	111);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (2, 'Avatar', 2009,	162);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (2, 'Titanic', 1997,	194);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (2, 'O Exterminador do Futuro', 1984,	107);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (3, 'O Estranho Mundo de Jack', 1993,	76);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (3, 'Alice no País das Maravilhas', 2010,	108);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (3, 'A Noiva Cadáver', 2005,	77);
                    INSERT Filmes (DiretorId, Titulo, Ano, Minutos) VALUES (3, 'A Fantástica Fábrica de Chocolate', 2005,	115);";

            await ExecutarComandoAsync(sql, DatabaseName);
        }

        private async Task ExecutarComandoAsync(string sql, string banco)
        {
            if (string.IsNullOrWhiteSpace(DatabaseServer))
            {
                throw new Exception("DatabaseServer precisa ser definido!");
            }

            SqlConnection conexao = new SqlConnection($"Server={DatabaseServer};Integrated security=SSPI;database={banco}");
            SqlCommand comando = new SqlCommand(sql, conexao);

            try
            {
                conexao.Open();

                await comando.ExecuteNonQueryAsync();

                Console.WriteLine("Script executado com sucesso.");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
        }

        #endregion Banco de dados
    }
}