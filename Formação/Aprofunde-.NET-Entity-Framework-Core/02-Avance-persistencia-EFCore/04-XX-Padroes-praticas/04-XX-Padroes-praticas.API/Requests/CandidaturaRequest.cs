using _04_XX_Padroes_praticas.Modelos;

namespace _04_XX_Padroes_praticas.API.Requests;

public record CandidaturaRequest(Guid Id, double ValorProposto, string? DescricaoProposta, DuracaoEmDias? DuracaoProposta, StatusCandidatura? Status, ServicoRequest Servico);