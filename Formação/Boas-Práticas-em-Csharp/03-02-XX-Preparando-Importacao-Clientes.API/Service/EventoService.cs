﻿using _03_02_XX_Preparando_Importacao_Clientes.API.Dados.Context;
using _03_02_XX_Preparando_Importacao_Clientes.API.Dominio;

namespace _03_02_XX_Preparando_Importacao_Clientes.API.Service
{
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
            };
            _context.Add(pet);
            _context.SaveChanges();
        }
    }
}