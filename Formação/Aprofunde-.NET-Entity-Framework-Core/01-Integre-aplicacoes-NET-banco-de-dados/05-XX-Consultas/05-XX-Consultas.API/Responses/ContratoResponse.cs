using _05_XX_Consultas.Modelos;

namespace _05_XX_Consultas.API.Responses;

public record ContratoResponse(Guid Id, double? Valor, Vigencia? Vigencia, Guid ServicoId, Guid ProfissionalId);