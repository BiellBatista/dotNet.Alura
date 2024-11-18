using _01_XX_Melhorando_consultas.Modelos;

namespace _01_XX_Melhorando_consultas.API.Responses;

public record ContratoResponse(Guid Id, double? Valor, Vigencia? Vigencia, Guid ServicoId, Guid ProfissionalId);