using _02_XX_Modelo_rico.Modelos;

namespace _02_XX_Modelo_rico.API.Responses;

public record ContratoResponse(Guid Id, double? Valor, Vigencia? Vigencia, Guid ServicoId, Guid ProfissionalId);