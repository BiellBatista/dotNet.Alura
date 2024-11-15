using _03_XX_Relacionamentos.Modelos;

namespace _03_XX_Relacionamentos.API.Requests;

public record CandidaturaRequest(Guid Id, double ValorProposto, string? DescricaoProposta, DuracaoEmDias? DuracaoProposta, StatusCandidatura? Status, ServicoRequest Servico);