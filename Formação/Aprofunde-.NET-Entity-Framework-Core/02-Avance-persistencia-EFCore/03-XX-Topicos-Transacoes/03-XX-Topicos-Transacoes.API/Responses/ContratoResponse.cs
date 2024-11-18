using _03_XX_Topicos_Transacoes.Modelos;

namespace _03_XX_Topicos_Transacoes.API.Responses;

public record ContratoResponse(Guid Id, double? Valor, Vigencia? Vigencia, Guid ServicoId, Guid ProfissionalId);