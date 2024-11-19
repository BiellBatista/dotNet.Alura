using _02_XX_Operacoes_lote.Modelos;

namespace _02_XX_Operacoes_lote.API.Requests;

public record ContratoRequest(Guid Id, double Valor, Vigencia? Vigencia, ServicoRequest Servico, ProfissionalRequest profissional);