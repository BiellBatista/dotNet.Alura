using _03_XX_Relacionamentos.Modelos;

namespace _03_XX_Relacionamentos.API.Responses;

public record ContratoResponse(Guid Id, double? Valor, Vigencia? Vigencia, Guid ServicoId, Guid ProfissionalId);