﻿using _03_XX_Logando_Usuario.Data;
using _03_XX_Logando_Usuario.Data.Dtos.Sessao;
using _03_XX_Logando_Usuario.Models;
using AutoMapper;
using System.Linq;

namespace _03_XX_Logando_Usuario.Services
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