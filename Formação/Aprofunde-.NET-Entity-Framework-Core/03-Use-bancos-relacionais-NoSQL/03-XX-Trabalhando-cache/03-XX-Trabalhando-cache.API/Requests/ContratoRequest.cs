using _03_XX_Trabalhando_cache.Modelos;

namespace _03_XX_Trabalhando_cache.API.Requests;

public record ContratoRequest(Guid Id, double Valor, Vigencia? Vigencia, ServicoRequest Servico, ProfissionalRequest profissional);