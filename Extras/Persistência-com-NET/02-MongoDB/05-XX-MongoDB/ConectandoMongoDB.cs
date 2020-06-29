using MongoDB.Driver;

namespace _05_XX_MongoDB
{
    class ConectandoMongoDB
    {
        public const string STRING_CONEXAO = "mongodb://localhost:27017";
        public const string NOME_DA_BASE = "Biblioteca";
        public const string NOME_DA_COLECAO = "Livros";

        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _baseDados;

        static ConectandoMongoDB()
        {
            _client = new MongoClient(STRING_CONEXAO);
            _baseDados = _client.GetDatabase(NOME_DA_BASE);
        }

        public IMongoClient Cliente
        {
            get { return _client; }
        }

        public IMongoCollection<Livro> Livros
        {
            get { return _baseDados.GetCollection<Livro>(NOME_DA_COLECAO); }
        }
    }
}
