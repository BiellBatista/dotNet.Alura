﻿using _05_XX_Disparando_Emails.Data;
using _05_XX_Disparando_Emails.Data.Dtos.Gerente;
using _05_XX_Disparando_Emails.Models;
using AutoMapper;
using FluentResults;
using System.Linq;

namespace _05_XX_Disparando_Emails.Services
{
    public class GerenteService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadGerenteDto AdicionaGerente(CreateGerenteDto dto)
        {
            Gerente gerente = _mapper.Map<Gerente>(dto);

            _context.Gerentes.Add(gerente);
            _context.SaveChanges();

            return _mapper.Map<ReadGerenteDto>(gerente);
        }

        public ReadGerenteDto RecuperaGerentesPorId(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if (gerente is not null)
                return _mapper.Map<ReadGerenteDto>(gerente);

            return null;
        }

        internal Result DeleteGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if (gerente is null)
                return Result.Fail("Gerente não encontrado");

            _context.Remove(gerente);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}