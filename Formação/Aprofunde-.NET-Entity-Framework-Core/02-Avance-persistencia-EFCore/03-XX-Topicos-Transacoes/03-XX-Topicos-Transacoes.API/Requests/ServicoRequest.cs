using _03_XX_Topicos_Transacoes.Modelos;

namespace _03_XX_Topicos_Transacoes.API.Requests;

public record ServicoRequest(Guid Id, string? Titulo, string? Descricao, StatusServico Status, ProjetoRequest Projeto);