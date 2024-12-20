﻿using _01_01_XX_Melhorando_Legibilidade.API.Dados.Context;
using _01_01_XX_Melhorando_Legibilidade.API.Dominio;

namespace _01_01_XX_Melhorando_Legibilidade.API.Service;

internal class EventoService : IEventoService
{
    private DataBaseContext _context;

    public EventoService(DataBaseContext context)
    {
        _context = context;
    }

    public void GenerateFakeDate()
    {
        var proprietario = new Cliente()
        {
            CPF = "111.111.111-22",
            Nome = "André",
            Email = "andre@email.com"
        };

        _context.Add(proprietario);

        var pet = new Pet()
        {
            Nome = "Sábio",
            Tipo = TipoPet.Gato,
            Proprietario = proprietario,
        };

        _context.Add(pet);
        _context.SaveChanges();
    }
}