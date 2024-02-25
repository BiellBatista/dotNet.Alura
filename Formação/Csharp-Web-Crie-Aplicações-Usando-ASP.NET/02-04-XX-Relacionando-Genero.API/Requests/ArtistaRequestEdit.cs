namespace _02_04_XX_Relacionando_Genero.API.Requests;

public record ArtistaRequestEdit(int Id, string nome, string bio)
    : ArtistaRequest(nome, bio);