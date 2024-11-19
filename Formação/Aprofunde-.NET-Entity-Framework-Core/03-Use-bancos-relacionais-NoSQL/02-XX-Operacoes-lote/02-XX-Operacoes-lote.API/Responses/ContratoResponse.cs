using _02_XX_Operacoes_lote.Modelos;

namespace _02_XX_Operacoes_lote.API.Responses;

public record ContratoResponse(Guid Id, double? Valor, Vigencia? Vigencia, Guid ServicoId, Guid ProfissionalId);