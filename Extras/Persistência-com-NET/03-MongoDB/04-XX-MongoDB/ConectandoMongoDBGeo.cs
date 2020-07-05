using MongoDB.Driver;

namespace _04_XX_MongoDB
{
    class ConectandoMongoDBGeo
    {
        public const string STRING_CONEXAO = "mongodb://localhost:27017";
        public const string NOME_DA_BASE = "geo";
        public const string NOME_DA_COLECAO = "airports";

        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _baseDados;

        static ConectandoMongoDBGeo()
        {
            _client = new MongoClient(STRING_CONEXAO);
            _baseDados = _client.GetDatabase(NOME_DA_BASE);
        }

        public IMongoClient Cliente
        {
            get { return _client; }
        }

        public IMongoCollection<Aeroporto> Airports
        {
            get { return _baseDados.GetCollection<Aeroporto>(NOME_DA_COLECAO); }
        }
    }
}
