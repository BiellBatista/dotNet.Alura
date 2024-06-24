namespace _09_01_XX_Preparando_Ambiente_Testes.API.DTO.Response;

public record OfertaViagemResponse(int Id, RotaResponse rota, PeriodoResponse periodo, double preco, double desconto);