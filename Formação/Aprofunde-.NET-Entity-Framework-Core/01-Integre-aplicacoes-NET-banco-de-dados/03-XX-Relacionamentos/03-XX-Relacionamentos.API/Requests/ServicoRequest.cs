using _03_XX_Relacionamentos.Modelos;

namespace _03_XX_Relacionamentos.API.Requests;

public record ServicoRequest(Guid Id, string? Titulo, string? Descricao, StatusServico Status, ProjetoRequest Projeto);