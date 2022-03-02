using _05_XX_Integrando_Aplicacao_Banco_Dados.Dominio.Entidades;
using System.Collections.Generic;

namespace _05_XX_Integrando_Aplicacao_Banco_Dados.Infraestrutura.Testes
{
    public interface IByteBankRepositorio
    {
        public List<Cliente> BuscarClientes();

        public List<Agencia> BuscarAgencias();

        public List<ContaCorrente> BuscarContasCorrentes();
    }
}