namespace Passagens
{
    /**
     * Implementando o contrado (interface) do serviço
     */
    public class ClienteService : IClienteService
    {
        public void Add(Cliente c)
        {
            ClienteDAO dao = new ClienteDAO();
            dao.Add(c);
        }

        public Cliente Buscar(string nome)
        {
            ClienteDAO dao = new ClienteDAO();
            return dao.Buscar(nome);
        }
    }
}
