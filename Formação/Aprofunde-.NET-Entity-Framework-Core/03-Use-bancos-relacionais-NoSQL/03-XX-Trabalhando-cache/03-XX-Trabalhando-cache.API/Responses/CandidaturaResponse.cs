namespace _03_XX_Trabalhando_cache.API.Responses;

public record CandidaturaResponse(Guid Id, double? ValorProposto, string? DescricaoProposta, string? DuracaoProposta, string? Status, Guid ServicoId);