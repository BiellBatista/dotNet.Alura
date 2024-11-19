using _04_XX_Seguranca.Modelos;

namespace _04_XX_Seguranca.API.Requests;

public record ContratoRequest(Guid Id, double Valor, Vigencia? Vigencia, ServicoRequest Servico, ProfissionalRequest profissional);