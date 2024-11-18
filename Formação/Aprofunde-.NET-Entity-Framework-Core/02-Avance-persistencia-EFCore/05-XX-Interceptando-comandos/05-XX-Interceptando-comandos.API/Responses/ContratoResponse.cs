using _05_XX_Interceptando_comandos.Modelos;

namespace _05_XX_Interceptando_comandos.API.Responses;

public record ContratoResponse(Guid Id, double? Valor, Vigencia? Vigencia, Guid ServicoId, Guid ProfissionalId);