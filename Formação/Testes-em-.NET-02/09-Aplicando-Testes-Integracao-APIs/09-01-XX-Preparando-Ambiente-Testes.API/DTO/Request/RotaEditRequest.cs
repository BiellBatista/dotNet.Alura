namespace _09_01_XX_Preparando_Ambiente_Testes.API.DTO.Request;

public record RotaEditRequest(int id, string origem, string destino) : RotaRequest(origem, destino);