using _05_XX_Interceptando_comandos.Modelos;

namespace _05_XX_Interceptando_comandos.API.Requests;

public record ContratoRequest(Guid Id, double Valor, Vigencia? Vigencia, ServicoRequest Servico, ProfissionalRequest profissional);