using _01_XX_Testes_Interface_Usando_Selenium.Domain.Entidades;
using System.Collections.Generic;

namespace _01_XX_Testes_Interface_Usando_Selenium.Infraestrutura.Testes
{
    public interface IByteBankRepositorio
    {
        public List<Cliente> BuscarClientes();

        public List<Agencia> BuscarAgencias();

        public List<ContaCorrente> BuscarContasCorrentes();
    }
}