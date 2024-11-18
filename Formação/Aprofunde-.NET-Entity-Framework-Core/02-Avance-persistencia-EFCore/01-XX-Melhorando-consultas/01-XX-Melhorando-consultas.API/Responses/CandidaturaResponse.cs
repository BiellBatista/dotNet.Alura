namespace _01_XX_Melhorando_consultas.API.Responses;

public record CandidaturaResponse(Guid Id, double? ValorProposto, string? DescricaoProposta, string? DuracaoProposta, string? Status, Guid ServicoId);