using AutoMapper;
using System;
using System.Collections.Generic;
using _05_XX_Testes_Interface_Usando_Selenium.Dominio.Interfaces.Servicos;
using _05_XX_Testes_Interface_Usando_Selenium.Dominio.Entidades;
using _05_XX_Testes_Interface_Usando_Selenium.Aplicacao.Interfaces;
using _05_XX_Testes_Interface_Usando_Selenium.Aplicacao.DTO;

namespace _05_XX_Testes_Interface_Usando_Selenium.Aplicacao.AplicacaoServico
{
    public class ClienteServicoApp : IClienteServicoApp
    {
        private readonly IClienteServico _servico;
        private readonly Mapper _mapper;

        public ClienteServicoApp(IClienteServico servico)
        {
            _servico = servico;
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Cliente, ClienteDTO>().ReverseMap());
            _mapper = new(config);
        }

        public void Dispose()
        {
            _servico.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool Adicionar(ClienteDTO cliente)
        {
            return _servico.Adicionar(_mapper.Map<ClienteDTO, Cliente>(cliente));
        }

        public bool Atualizar(int id, ClienteDTO cliente)
        {
            return _servico.Atualizar(id, _mapper.Map<ClienteDTO, Cliente>(cliente));
        }

        public bool Excluir(int id)
        {
            return _servico.Excluir(id);
        }

        public ClienteDTO ObterPorId(int id)
        {
            return _mapper.Map<Cliente, ClienteDTO>(_servico.ObterPorId(id));
        }

        public ClienteDTO ObterPorGuid(Guid guid)
        {
            return _mapper.Map<Cliente, ClienteDTO>(_servico.ObterPorGuid(guid));
        }

        public List<ClienteDTO> ObterTodos()
        {
            var clientes = _servico.ObterTodos();
            List<ClienteDTO> clientesDTO = _mapper.Map<List<Cliente>, List<ClienteDTO>>(clientes);
            return clientesDTO;
        }
    }
}