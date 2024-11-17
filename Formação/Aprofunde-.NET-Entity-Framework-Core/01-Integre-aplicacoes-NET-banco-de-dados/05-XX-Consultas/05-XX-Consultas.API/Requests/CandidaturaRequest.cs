using _05_XX_Consultas.Modelos;

namespace _05_XX_Consultas.API.Requests;

public record CandidaturaRequest(Guid Id, double ValorProposto, string? DescricaoProposta, DuracaoEmDias? DuracaoProposta, StatusCandidatura? Status, ServicoRequest Servico);