﻿namespace _09_01_XX_Preparando_Ambiente_Testes.API.DTO.Request;

public record OfertaViagemEditRequest(int Id, double desconto, RotaRequest rota, PeriodoRequest periodo, double preco) : OfertaViagemRequest(rota, periodo, preco, desconto);