using _03_XX_Trabalhando_cache.Dados.Repository.Interfaces;

namespace _03_XX_Trabalhando_cache.Dados.UnitOfWork;

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