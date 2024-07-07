namespace _10_01_XX_Pipeline_Testes_GitHub_Actions.API.DTO.Request;

public record RotaEditRequest(int id, string origem, string destino) : RotaRequest(origem, destino);