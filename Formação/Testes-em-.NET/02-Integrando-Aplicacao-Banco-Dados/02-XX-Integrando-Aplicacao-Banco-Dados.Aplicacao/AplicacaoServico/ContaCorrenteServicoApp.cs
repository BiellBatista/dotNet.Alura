﻿using _02_XX_Integrando_Aplicacao_Banco_Dados.Aplicacao.DTO;
using _02_XX_Integrando_Aplicacao_Banco_Dados.Aplicacao.Interfaces;
using _02_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Entidades;
using _02_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Interfaces.Servicos;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace _02_XX_Integrando_Aplicacao_Banco_Dados.Aplicacao.AplicacaoServico
{
    public class ContaCorrenteServicoApp : IContaCorrenteServicoApp
    {
        private readonly IContaCorrenteServico _servico;
        private readonly Mapper _mapper;

        public ContaCorrenteServicoApp(IContaCorrenteServico servico)
        {
            _servico = servico;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ContaCorrente, ContaCorrenteDTO>().ReverseMap();
                cfg.CreateMap<Cliente, ClienteDTO>().ReverseMap();
                cfg.CreateMap<Agencia, AgenciaDTO>().ReverseMap();
            });
            _mapper = new(config);
        }

        public void Dispose()
        {
            _servico.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Adicionar(ContaCorrenteDTO conta)
        {
            return _servico.Adicionar(_mapper.Map<ContaCorrenteDTO, ContaCorrente>(conta));
        }

        public bool Atualizar(int id, ContaCorrenteDTO conta)
        {
            return _servico.Atualizar(id, _mapper.Map<ContaCorrenteDTO, ContaCorrente>(conta));
        }

        public bool Excluir(int id)
        {
            return _servico.Excluir(id);
        }

        public ContaCorrenteDTO ObterPorId(int id)
        {
            return _mapper.Map<ContaCorrente, ContaCorrenteDTO>(_servico.ObterPorId(id));
        }

        public ContaCorrenteDTO ObterPorGuid(Guid guid)
        {
            return _mapper.Map<ContaCorrente, ContaCorrenteDTO>(_servico.ObterPorGuid(guid));
        }

        public List<ContaCorrenteDTO> ObterTodos()
        {
            var contas = _servico.ObterTodos();
            List<ContaCorrenteDTO> contasDTO = _mapper.Map<List<ContaCorrente>, List<ContaCorrenteDTO>>(contas);
            return contasDTO;
        }
    }
}