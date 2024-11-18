using _04_XX_Padroes_praticas.Modelos;

namespace _04_XX_Padroes_praticas.API.Responses;

public record ContratoResponse(Guid Id, double? Valor, Vigencia? Vigencia, Guid ServicoId, Guid ProfissionalId);