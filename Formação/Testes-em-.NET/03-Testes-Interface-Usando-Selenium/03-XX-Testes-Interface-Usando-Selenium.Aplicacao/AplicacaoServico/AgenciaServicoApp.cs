﻿using _03_XX_Testes_Interface_Usando_Selenium.Domain.Entidades;
using _03_XX_Testes_Interface_Usando_Selenium.Domain.Interfaces.Servicos;
using AutoMapper;
using System;
using System.Collections.Generic;
using _03_XX_Testes_Interface_Usando_Selenium.Aplicacao.DTO;
using _03_XX_Testes_Interface_Usando_Selenium.Aplicacao.Interfaces;

namespace _03_XX_Testes_Interface_Usando_Selenium.Aplicacao.AplicacaoServico
{
    public class AgenciaServicoApp : IAgenciaServicoApp
    {
        private readonly IAgenciaServico _servico;
        private readonly Mapper _mapper;

        public AgenciaServicoApp(IAgenciaServico servico)
        {
            _servico = servico;
            var config = new MapperConfiguration(cfg =>
                   cfg.CreateMap<Agencia, AgenciaDTO>().ReverseMap());
            _mapper = new(config);
        }

        public void Dispose()
        {
            _servico.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Adicionar(AgenciaDTO agencia)
        {
            return _servico.Adicionar(_mapper.Map<AgenciaDTO, Agencia>(agencia));
        }

        public bool Atualizar(int id, AgenciaDTO agencia)
        {
            return _servico.Atualizar(id, _mapper.Map<AgenciaDTO, Agencia>(agencia));
        }

        public bool Excluir(int id)
        {
            return _servico.Excluir(id);
        }

        public AgenciaDTO ObterPorId(int id)
        {
            return _mapper.Map<Agencia, AgenciaDTO>(_servico.ObterPorId(id));
        }

        public AgenciaDTO ObterPorGuid(Guid guid)
        {
            return _mapper.Map<Agencia, AgenciaDTO>(_servico.ObterPorGuid(guid));
        }

        public List<AgenciaDTO> ObterTodos()
        {
            var agencias = _servico.ObterTodos();
            List<AgenciaDTO> agenciasDTO = _mapper.Map<List<Agencia>, List<AgenciaDTO>>(agencias);
            return agenciasDTO;
        }
    }
}