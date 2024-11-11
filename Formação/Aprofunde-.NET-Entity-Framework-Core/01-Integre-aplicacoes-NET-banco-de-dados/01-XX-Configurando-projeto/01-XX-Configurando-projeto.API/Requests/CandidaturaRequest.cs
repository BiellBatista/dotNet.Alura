namespace _01_XX_Configurando_projeto.API.Requests;

public record CandidaturaRequest(Guid Id, double? ValorProposto, string? DescricaoProposta, ProfissionalRequest? Profissional, ServicoRequest? Servico, string? DuracaoProposta, string? Status);