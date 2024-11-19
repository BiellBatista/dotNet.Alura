namespace _04_XX_Seguranca.API.Responses;

public record CandidaturaResponse(Guid Id, double? ValorProposto, string? DescricaoProposta, string? DuracaoProposta, string? Status, Guid ServicoId);