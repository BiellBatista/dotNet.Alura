using _03_05_XX_CasaDoCodigo.Models;
using System;
using System.Linq;

namespace _03_05_XX_CasaDoCodigo.Repositories
{
    public interface ICadastroRepository
    {
        Cadastro Update(int cadastroId, Cadastro novoCadastro);
    }

    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public Cadastro Update(int cadastroId, Cadastro novoCadastro)
        {
            var cadastroDb = dbSet.Where(c => c.Id == cadastroId).SingleOrDefault();

            if (cadastroDb is null)
                throw new ArgumentNullException("cadastro");

            cadastroDb.Update(novoCadastro);
            contexto.SaveChanges();

            return cadastroDb;
        }
    }
}
