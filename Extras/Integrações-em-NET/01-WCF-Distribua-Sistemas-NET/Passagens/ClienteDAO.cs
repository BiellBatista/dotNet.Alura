using System.Collections.Generic;
using System.Linq;

namespace Passagens
{
    public class ClienteDAO
    {
        private List<Cliente> cliente = new List<Cliente>();

        public void Add(Cliente c)
        {
            cliente.Add(c);
        }

        public Cliente Buscar(string nome)
        {
            var resultado = from c in cliente where c.Nome.Equals(nome) select c;
            return (Cliente) resultado;
        }
    }
}
