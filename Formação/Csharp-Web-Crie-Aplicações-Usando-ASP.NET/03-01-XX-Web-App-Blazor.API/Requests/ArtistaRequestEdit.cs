namespace _03_01_XX_Web_App_Blazor.API.Requests;

public record ArtistaRequestEdit(int Id, string nome, string bio)
    : ArtistaRequest(nome, bio);