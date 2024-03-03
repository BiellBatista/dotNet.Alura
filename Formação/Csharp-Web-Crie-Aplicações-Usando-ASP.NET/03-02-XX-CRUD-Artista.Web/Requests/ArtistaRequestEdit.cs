namespace _03_02_XX_CRUD_Artista.Web.Requests;

public record ArtistaRequestEdit(int Id, string nome, string bio)
    : ArtistaRequest(nome, bio);