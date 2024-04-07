namespace _04_04_XX_Autorizacao_APP_Web.API.Requests;

public record MusicaRequestEdit(int Id, string nome, int ArtistaId, int anoLancamento)
    : MusicaRequest(nome, ArtistaId, anoLancamento);