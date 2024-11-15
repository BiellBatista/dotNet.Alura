﻿namespace _02_XX_Mapeamentos_explicitos.Modelos;

public class Cliente
{
    public Cliente()
    {
    }

    public Cliente(Guid id, string nome, string cpf, string email, string telefone)
    {
        this.Id = id;
        this.Nome = nome;
        this.Cpf = cpf;
        this.Email = email;
        this.Telefone = telefone;
    }

    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
}