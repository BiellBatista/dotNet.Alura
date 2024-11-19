using _01_XX_Explorando_procedure.Dados.Repository.Interfaces;

namespace _01_XX_Explorando_procedure.Dados.UnitOfWork;

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