namespace _10_02_XX_TestContainer.API.DTO.Request;

public record RotaEditRequest(int id, string origem, string destino) : RotaRequest(origem, destino);