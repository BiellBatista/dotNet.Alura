using _05_XX_Interceptando_comandos.Modelos;

namespace _05_XX_Interceptando_comandos.API.Requests;

public record ServicoRequest(Guid Id, string? Titulo, string? Descricao, StatusServico Status, ProjetoRequest Projeto);