using System.Collections.Generic;

namespace Passagens
{
    /**
     * Implementando o contrado (interface) do serviço
     */
    public class ClienteService : IClienteService
    {
        public bool Add(string nome, string cpf)
        {
            Cliente cliente = new Cliente();
            ClienteDAO dao = new ClienteDAO();

            cliente.Nome = nome;
            cliente.Cpf = cpf;

            dao.Add(cliente);

            return true;
        }

        public Cliente Buscar(string nome)
        {
            ClienteDAO dao = new ClienteDAO();
            return dao.Buscar(nome);
        }

        public List<Cliente> getClientes()
        {
            return ClienteDAO.clientes;
        }
    }
}
