﻿using _02_XX_Conhecendo_Identity.Data;
using _02_XX_Conhecendo_Identity.Data.Dtos.Sessao;
using _02_XX_Conhecendo_Identity.Models;
using AutoMapper;
using System.Linq;

namespace _02_XX_Conhecendo_Identity.Services
{
    public class SessaoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadSessaoDto AdicionaSessao(CreateSessaoDto dto)
        {
            Sessao sessao = _mapper.Map<Sessao>(dto);

            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public ReadSessaoDto RecuperaSessoesPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if (sessao is not null)

                return _mapper.Map<ReadSessaoDto>(sessao);

            return null;
        }
    }
}