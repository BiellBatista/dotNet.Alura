﻿using _03_XX_Logando_Usuario.Data;
using _03_XX_Logando_Usuario.Data.Dtos.Endereco;
using _03_XX_Logando_Usuario.Models;
using AutoMapper;
using FluentResults;
using System.Collections.Generic;
using System.Linq;

namespace _03_XX_Logando_Usuario.Services
{
    public class EnderecoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return _mapper.Map<ReadEnderecoDto>(endereco);
        }

        public List<ReadEnderecoDto> RecuperaEnderecos()
        {
            List<Endereco> enderecos = _context.Enderecos.ToList();

            if (enderecos is null)
                return null;

            return _mapper.Map<List<ReadEnderecoDto>>(enderecos);
        }

        internal ReadEnderecoDto RecuperaEnderecosPorId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if (endereco is not null)
                return _mapper.Map<ReadEnderecoDto>(endereco);

            return null;
        }

        public Result AtualizaEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if (endereco is null)
                return Result.Fail("Endereço não encontrado");

            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();

            return Result.Ok();
        }

        internal Result DeletaEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if (endereco is null)
                return Result.Fail("Endereco não encontrado");

            _context.Remove(endereco);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}