using _02_05_XX_CasaDoCodigo.Models;

namespace _02_05_XX_CasaDoCodigo.Repositories
{
    public interface ICadastroRepository
    {

    }

    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}
