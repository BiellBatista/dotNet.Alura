using _03_XX_Relacionamentos.Modelos;

namespace _03_XX_Relacionamentos.API.Requests;

public record ContratoRequest(Guid Id, double Valor, Vigencia? Vigencia, ServicoRequest Servico, ProfissionalRequest Profissional);