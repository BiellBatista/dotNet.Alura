namespace _10_03_XX_Publicando_Pipeline.API.DTO.Request;

public record RotaEditRequest(int id, string origem, string destino) : RotaRequest(origem, destino);