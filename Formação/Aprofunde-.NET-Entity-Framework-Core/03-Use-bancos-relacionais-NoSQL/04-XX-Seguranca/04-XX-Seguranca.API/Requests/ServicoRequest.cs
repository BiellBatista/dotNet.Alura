using _04_XX_Seguranca.Modelos;

namespace _04_XX_Seguranca.API.Requests;

public record ServicoRequest(Guid Id, string? Titulo, string? Descricao, StatusServico Status, ProjetoRequest Projeto);