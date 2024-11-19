using _04_XX_Seguranca.Dados.Repository.Base;
using _04_XX_Seguranca.Dados.Repository.Interfaces;
using _04_XX_Seguranca.Modelos;

namespace _04_XX_Seguranca.Dados.Repository;

public class ProjetoRepository : Repository<Projeto>, IProjetoRepository
{
    public ProjetoRepository(FreelandoContext context) : base(context)
    {
    }
}