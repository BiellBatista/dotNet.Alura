namespace _09_05_XX_Desafio.API.Requests;

public record ArtistaRequestEdit(int Id, string nome, string bio)
    : ArtistaRequest(nome, bio);