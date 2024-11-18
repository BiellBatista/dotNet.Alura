using _01_XX_Melhorando_consultas.Modelos;

namespace _01_XX_Melhorando_consultas.API.Requests;

public record ContratoRequest(Guid Id, double Valor, Vigencia? Vigencia, ServicoRequest Servico, ProfissionalRequest profissional);