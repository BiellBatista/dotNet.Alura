using _02_XX_Operacoes_lote.Modelos;

namespace _02_XX_Operacoes_lote.API.Requests;

public record ServicoRequest(Guid Id, string? Titulo, string? Descricao, StatusServico Status, ProjetoRequest Projeto);