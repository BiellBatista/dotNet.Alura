using _04_XX_Padroes_praticas.Modelos;

namespace _04_XX_Padroes_praticas.API.Requests;

public record ServicoRequest(Guid Id, string? Titulo, string? Descricao, StatusServico Status, ProjetoRequest Projeto);