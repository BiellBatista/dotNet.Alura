using MongoDB.Driver;

namespace _01_XX_MongoDB.Models
{
    public class AcessoMongoDB
    {
        public const string STRING_CONEXAO = "mongodb://localhost:27017";
        public const string NOME_DA_BASE = "Blog";
        public const string NOME_DA_COLECAO_PUBLICACAO = "Publicacoes";
        public const string NOME_DA_COLECAO_USUARIO = "Usuarios";

        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _baseDados;

        static AcessoMongoDB()
        {
            _client = new MongoClient(STRING_CONEXAO);
            _baseDados = _client.GetDatabase(NOME_DA_BASE);
        }

        public IMongoClient Cliente
        {
            get { return _client; }
        }

        public IMongoCollection<Publicacao> Publicacoes
        {
            get { return _baseDados.GetCollection<Publicacao>(NOME_DA_COLECAO_PUBLICACAO); }
        }

        public IMongoCollection<Usuario> Usuarios
        {
            get { return _baseDados.GetCollection<Usuario>(NOME_DA_COLECAO_USUARIO); }
        }
    }
}
