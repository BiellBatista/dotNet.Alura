using _03_XX_Topicos_Transacoes.Modelos;

namespace _03_XX_Topicos_Transacoes.API.Requests;

public record ContratoRequest(Guid Id, double Valor, Vigencia? Vigencia, ServicoRequest Servico, ProfissionalRequest profissional);