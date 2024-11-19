using _02_XX_Operacoes_lote.Modelos;

namespace _02_XX_Operacoes_lote.API.Requests;

public record CandidaturaRequest(Guid Id, double ValorProposto, string? DescricaoProposta, DuracaoEmDias? DuracaoProposta, StatusCandidatura? Status, ServicoRequest Servico);