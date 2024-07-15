namespace _10_05_XX_Fluxo_Completo.API.DTO.Request;

public record RotaEditRequest(int id, string origem, string destino) : RotaRequest(origem, destino);