using _04_XX_Salvando_dados.Modelos;

namespace _04_XX_Salvando_dados.API.Requests;

public record ContratoRequest(Guid Id, double Valor, Vigencia? Vigencia, ServicoRequest Servico, ProfissionalRequest Profissional);