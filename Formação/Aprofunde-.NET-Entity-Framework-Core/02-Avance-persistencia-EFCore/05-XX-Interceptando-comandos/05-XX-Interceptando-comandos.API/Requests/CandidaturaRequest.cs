using _05_XX_Interceptando_comandos.Modelos;

namespace _05_XX_Interceptando_comandos.API.Requests;

public record CandidaturaRequest(Guid Id, double ValorProposto, string? DescricaoProposta, DuracaoEmDias? DuracaoProposta, StatusCandidatura? Status, ServicoRequest Servico);