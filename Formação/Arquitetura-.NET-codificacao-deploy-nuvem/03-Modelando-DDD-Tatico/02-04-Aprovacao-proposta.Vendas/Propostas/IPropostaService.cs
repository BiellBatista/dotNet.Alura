using _02_04_Aprovacao_proposta.Contracts;
using _02_04_Aprovacao_proposta.Vendas.Locacoes;
using System.Transactions;

namespace _02_04_Aprovacao_proposta.Vendas.Propostas;

public interface IPropostaService
{
    Task<Proposta?> AprovarAsync(AprovarProposta comando);

    Task<Proposta?> ComentarAsync(ComentarProposta comando);
}

public class PropostaService : IPropostaService
{
    private readonly IRepository<Proposta> repoProposta;
    private readonly IRepository<Locacao> repoLocacao;

    public PropostaService(IRepository<Proposta> repoProposta, IRepository<Locacao> repoLocacao)
    {
        this.repoProposta = repoProposta;
        this.repoLocacao = repoLocacao;
    }

    public async Task<Proposta?> AprovarAsync(AprovarProposta comando)
    {
        var proposta = await repoProposta
                .GetFirstAsync(
                    p => p.Id == comando.IdProposta && p.SolicitacaoId == comando.IdPedido,
                    p => p.Id);
        if (proposta is null) return null;

        proposta.Situacao = SituacaoProposta.Aceita;

        // criar locação a partir da proposta aceita
        var locacao = new Locacao()
        {
            PropostaId = proposta.Id,
            DataInicio = DateTime.Now,
            DataPrevistaEntrega = proposta.Solicitacao.DataInicioOperacao.AddDays(-proposta.Solicitacao.DisponibilidadePrevia),
            DataTermino = proposta.Solicitacao.DataInicioOperacao.AddDays(proposta.Solicitacao.DuracaoPrevistaLocacao)
        };

        using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        await repoProposta.UpdateAsync(proposta);
        await repoLocacao.AddAsync(locacao);

        scope.Complete();
        return proposta;
    }

    public async Task<Proposta?> ComentarAsync(ComentarProposta comando)
    {
        var proposta = await repoProposta
                .GetFirstAsync(
                    p => p.Id == comando.IdProposta && p.SolicitacaoId == comando.IdPedido,
                    p => p.Id);
        if (proposta is null) return null;

        proposta.AddComentario(new Comentario()
        {
            Id = Guid.NewGuid(),
            Data = DateTime.Now,
            Usuario = comando.Pessoa,
            Texto = comando.Mensagem
        });

        await repoProposta.UpdateAsync(proposta);
        return proposta;
    }
}