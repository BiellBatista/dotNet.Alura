namespace _01_XX_Integracao_Entrega_Continua_Azure_DevOps.Apresentacao.Comandos
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