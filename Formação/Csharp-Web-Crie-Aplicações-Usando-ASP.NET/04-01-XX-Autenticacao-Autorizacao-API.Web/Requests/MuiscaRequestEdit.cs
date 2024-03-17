namespace _04_01_XX_Autenticacao_Autorizacao_API.Web.Requests;

public record MusicaRequestEdit(int Id, string nome, int ArtistaId, int anoLancamento)
    : MusicaRequest(nome, ArtistaId, anoLancamento);