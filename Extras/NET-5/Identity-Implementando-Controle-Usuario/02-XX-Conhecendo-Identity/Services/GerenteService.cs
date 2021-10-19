﻿using _02_XX_Conhecendo_Identity.Data;
using _02_XX_Conhecendo_Identity.Data.Dtos.Gerente;
using _02_XX_Conhecendo_Identity.Models;
using AutoMapper;
using FluentResults;
using System.Linq;

namespace _02_XX_Conhecendo_Identity.Services
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