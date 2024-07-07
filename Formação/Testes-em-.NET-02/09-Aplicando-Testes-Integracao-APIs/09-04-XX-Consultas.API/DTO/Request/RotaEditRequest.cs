namespace _09_04_XX_Consultas.API.DTO.Request;

public record RotaEditRequest(int id, string origem, string destino) : RotaRequest(origem, destino);