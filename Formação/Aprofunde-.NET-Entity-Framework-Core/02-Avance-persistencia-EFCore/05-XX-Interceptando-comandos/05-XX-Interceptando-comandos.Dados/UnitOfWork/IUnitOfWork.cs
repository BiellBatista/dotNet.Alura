using _05_XX_Interceptando_comandos.Dados.Repository;
using _05_XX_Interceptando_comandos.Dados.Repository.Interfaces;

namespace _05_XX_Interceptando_comandos.Dados.UnitOfWork;

public interface IUnitOfWork
{
    IEspecialidadeRepository EspecialidadeRepository { get; }
    IContratoRepository ContratoRepository { get; }
    IClienteRepository ClienteRepository { get; }
    IProfissionalRepository ProfissionalRepository { get; }
    IProjetoRepository ProjetoRepository { get; }
    IServicoRepository ServicoRepository { get; }
    ICandidaturaRepository CandidaturaRepository { get; }

    FreelandoContext contexto { get; }

    Task Commit();
}