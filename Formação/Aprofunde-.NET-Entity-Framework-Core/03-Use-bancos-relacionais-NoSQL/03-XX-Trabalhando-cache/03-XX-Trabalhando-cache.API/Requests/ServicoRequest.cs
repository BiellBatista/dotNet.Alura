using _03_XX_Trabalhando_cache.Modelos;

namespace _03_XX_Trabalhando_cache.API.Requests;

public record ServicoRequest(Guid Id, string? Titulo, string? Descricao, StatusServico Status, ProjetoRequest Projeto);