using _04_XX_Padroes_praticas.Dados.Repository.Base;
using _04_XX_Padroes_praticas.Dados.Repository.Interfaces;
using _04_XX_Padroes_praticas.Modelos;

namespace _04_XX_Padroes_praticas.Dados.Repository;

public class ProjetoRepository : Repository<Projeto>, IProjetoRepository
{
    public ProjetoRepository(FreelandoContext context) : base(context)
    {
    }
}