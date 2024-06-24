﻿using _09_02_XX_Compartilhando_Contexto.Dominio.Validacao;
using _09_02_XX_Compartilhando_Contexto.Dominio.ValueObjects;

namespace _09_02_XX_Compartilhando_Contexto.Dominio.Entidades;

public class OfertaViagem : Valida
{
    public const double DESCONTO_MAXIMO = 0.7;
    private double desconto;
    public int Id { get; set; }
    public virtual Rota Rota { get; set; }
    public Periodo Periodo { get; set; } // ValueObject (DDD)
    public double Preco { get; set; }

    public OfertaViagem()
    {
    }

    public double Desconto
    {
        get => desconto;
        set
        {
            desconto = value;
            if (desconto >= Preco)
            {
                Preco *= 1 - DESCONTO_MAXIMO;
            }
            else
            {
                Preco -= desconto;
            }
        }
    }

    public OfertaViagem(Rota rota, Periodo periodo, double preco)
    {
        Rota = rota;
        Periodo = periodo;
        Preco = preco;
        Validar();
    }

    public override string ToString()
    {
        return $"Origem: {Rota.Origem}, Destino: {Rota.Destino}, Data de Ida: {Periodo.DataInicial.ToShortDateString()}, Data de Volta: {Periodo.DataFinal.ToShortDateString()}, Preço: {Preco:C}";
    }

    protected override void Validar()
    {
        if (!Periodo.EhValido)
        {
            Erros.RegistrarErro(Periodo.Erros.Sumario);
        }
        else if (Rota == null || Periodo == null)
        {
            Erros.RegistrarErro("A oferta de viagem não possui rota ou período válidos.");
        }
        else if (Preco <= 0)
        {
            Erros.RegistrarErro("O preço da oferta de viagem deve ser maior que zero.");
        }
    }
}