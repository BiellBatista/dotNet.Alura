using _04_XX_Salvando_dados.Modelos;

namespace _04_XX_Salvando_dados.API.Responses;

public record ContratoResponse(Guid Id, double? Valor, Vigencia? Vigencia, Guid ServicoId, Guid ProfissionalId);