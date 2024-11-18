using _04_XX_Padroes_praticas.Modelos;

namespace _04_XX_Padroes_praticas.API.Requests;

public record ContratoRequest(Guid Id, double Valor, Vigencia? Vigencia, ServicoRequest Servico, ProfissionalRequest profissional);