using _03_XX_CI_CD_Azure_DevOps.Application.DTO;
using _03_XX_CI_CD_Azure_DevOps.Application.Interfaces;
using _03_XX_CI_CD_Azure_DevOps.Domain.Entidades;
using _03_XX_CI_CD_Azure_DevOps.Domain.Interfaces.Servicos;
using AutoMapper;

namespace _03_XX_CI_CD_Azure_DevOps.Application.AplicacaoServico
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