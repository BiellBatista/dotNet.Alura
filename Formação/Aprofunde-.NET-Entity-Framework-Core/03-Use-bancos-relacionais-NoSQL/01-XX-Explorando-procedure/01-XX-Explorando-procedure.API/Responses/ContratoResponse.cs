using _01_XX_Explorando_procedure.Modelos;

namespace _01_XX_Explorando_procedure.API.Responses;

public record ContratoResponse(Guid Id, double? Valor, Vigencia? Vigencia, Guid ServicoId, Guid ProfissionalId);