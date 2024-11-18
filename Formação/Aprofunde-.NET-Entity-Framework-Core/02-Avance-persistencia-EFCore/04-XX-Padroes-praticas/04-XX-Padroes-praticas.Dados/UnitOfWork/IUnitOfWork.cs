using _04_XX_Padroes_praticas.Dados.Repository.Interfaces;

namespace _04_XX_Padroes_praticas.Dados.UnitOfWork;

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