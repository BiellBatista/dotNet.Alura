namespace _10_04_XX_Criando_Pipeline_Azure_Devops.API.DTO.Response;

public record OfertaViagemResponse(int Id, RotaResponse rota, PeriodoResponse periodo, double preco);