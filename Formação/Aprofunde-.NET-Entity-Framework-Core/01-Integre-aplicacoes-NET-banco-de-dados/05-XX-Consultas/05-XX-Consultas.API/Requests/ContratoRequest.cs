using _05_XX_Consultas.Modelos;

namespace _05_XX_Consultas.API.Requests;

public record ContratoRequest(Guid Id, double Valor, Vigencia? Vigencia, ServicoRequest Servico, ProfissionalRequest Profissional);