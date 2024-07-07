namespace _09_03_XX_Testes_Endpoints.HTTPS.API.DTO.Request;

public record RotaEditRequest(int id, string origem, string destino) : RotaRequest(origem, destino);