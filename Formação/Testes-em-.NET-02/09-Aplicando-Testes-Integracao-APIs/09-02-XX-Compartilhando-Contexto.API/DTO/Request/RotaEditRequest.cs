namespace _09_02_XX_Compartilhando_Contexto.API.DTO.Request;

public record RotaEditRequest(int id, string origem, string destino) : RotaRequest(origem, destino);