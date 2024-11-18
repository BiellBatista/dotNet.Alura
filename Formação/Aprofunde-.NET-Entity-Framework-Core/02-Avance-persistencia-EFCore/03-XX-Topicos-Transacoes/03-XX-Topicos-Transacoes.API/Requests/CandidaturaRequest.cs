using _03_XX_Topicos_Transacoes.Modelos;

namespace _03_XX_Topicos_Transacoes.API.Requests;

public record CandidaturaRequest(Guid Id, double ValorProposto, string? DescricaoProposta, DuracaoEmDias? DuracaoProposta, StatusCandidatura? Status, ServicoRequest Servico);