using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;

namespace Alura.Filmes.App.Dados
{
    class AluraFilmesContexto : DbContext
    {
        //segunda informação: propriedades (tabelas) gerenciadas pelo entity
        //por default, o nome da propriedade DbSet deve ser igual ao nome da tabela
        public DbSet<Ator> Atores { get; set; }

        //primeira informação: conexao com o banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AluraFilmes;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
