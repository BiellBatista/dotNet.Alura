using _01_XX_Explorando_procedure.Modelos;

namespace _01_XX_Explorando_procedure.API.Requests;

public record ContratoRequest(Guid Id, double Valor, Vigencia? Vigencia, ServicoRequest Servico, ProfissionalRequest profissional);