namespace _01_XX_Explorando_procedure.API.Responses;

public record CandidaturaResponse(Guid Id, double? ValorProposto, string? DescricaoProposta, string? DuracaoProposta, string? Status, Guid ServicoId);