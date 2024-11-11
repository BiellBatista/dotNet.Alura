namespace _01_XX_Configurando_projeto.API.Responses;

public record CandidaturaResponse(Guid Id, double? ValorProposto, string? DescricaoProposta, ProfissionalResponse? Profissional, ServicoResponse? Servico, string? DuracaoProposta, string? Status);