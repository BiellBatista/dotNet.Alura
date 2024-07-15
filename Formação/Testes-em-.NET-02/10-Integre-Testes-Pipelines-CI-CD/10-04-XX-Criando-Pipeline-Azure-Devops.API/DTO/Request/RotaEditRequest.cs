namespace _10_04_XX_Criando_Pipeline_Azure_Devops.API.DTO.Request;

public record RotaEditRequest(int id, string origem, string destino) : RotaRequest(origem, destino);