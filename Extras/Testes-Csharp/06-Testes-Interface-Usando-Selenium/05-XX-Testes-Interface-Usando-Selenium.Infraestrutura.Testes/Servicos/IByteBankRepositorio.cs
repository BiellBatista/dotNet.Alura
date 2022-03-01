using _05_XX_Testes_Interface_Usando_Selenium.Dominio.Entidades;
using System.Collections.Generic;

namespace _05_XX_Testes_Interface_Usando_Selenium.Infraestrutura.Testes
{
    public interface IByteBankRepositorio
    {
        public List<Cliente> BuscarClientes();

        public List<Agencia> BuscarAgencias();

        public List<ContaCorrente> BuscarContasCorrentes();
    }
}