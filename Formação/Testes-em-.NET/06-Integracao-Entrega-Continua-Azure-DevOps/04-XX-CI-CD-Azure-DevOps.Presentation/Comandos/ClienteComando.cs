using _04_XX_CI_CD_Azure_DevOps.Data.Repositorio;
using _04_XX_CI_CD_Azure_DevOps.Domain.Services;
using _04_XX_CI_CD_Azure_DevOps.Application.AplicacaoServico;
using _04_XX_CI_CD_Azure_DevOps.Application.DTO;
using _04_XX_CI_CD_Azure_DevOps.Domain.Interfaces.Repositorios;
using _04_XX_CI_CD_Azure_DevOps.Domain.Interfaces.Servicos;

namespace _04_XX_CI_CD_Azure_DevOps.Presentation.Comandos
{
    internal class ClienteComando
    {
        private IClienteRepositorio _repositorio;
        private IClienteServico _servico;
        private ClienteServicoApp clienteServicoApp;

        public ClienteComando()
        {
            _repositorio = new ClienteRepositorio();
            _servico = new ClienteServico(_repositorio);
            clienteServicoApp = new ClienteServicoApp(_servico);
        }

        public bool Adicionar(ClienteDTO cliente)
        {
            return clienteServicoApp.Adicionar(cliente);
        }

        public bool Atualizar(int id, ClienteDTO cliente)
        {
            return clienteServicoApp.Atualizar(id, cliente);
        }

        public bool Excluir(int id)
        {
            return clienteServicoApp.Excluir(id);
        }

        public ClienteDTO ObterPorId(int id)
        {
            return clienteServicoApp.ObterPorId(id);
        }

        public ClienteDTO ObterPorGuid(Guid guid)
        {
            return clienteServicoApp.ObterPorGuid(guid);
        }

        public List<ClienteDTO> ObterTodos()
        {
            return clienteServicoApp.ObterTodos();
        }
    }
}