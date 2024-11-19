using _04_XX_Seguranca.Modelos;

namespace _04_XX_Seguranca.API.Responses;

public record ContratoResponse(Guid Id, double? Valor, Vigencia? Vigencia, Guid ServicoId, Guid ProfissionalId);