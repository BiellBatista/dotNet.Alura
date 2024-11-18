using _02_XX_Modelo_rico.Modelos;

namespace _02_XX_Modelo_rico.API.Requests;

public record ContratoRequest(Guid Id, double Valor, Vigencia? Vigencia, ServicoRequest Servico, ProfissionalRequest profissional);