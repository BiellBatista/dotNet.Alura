using _01_XX_Explorando_procedure.Modelos;

namespace _01_XX_Explorando_procedure.API.Requests;

public record CandidaturaRequest(Guid Id, double ValorProposto, string? DescricaoProposta, DuracaoEmDias? DuracaoProposta, StatusCandidatura? Status, ServicoRequest Servico);