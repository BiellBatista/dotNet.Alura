﻿using _03_XX_CI_CD_Azure_DevOps.Domain.Entidades;

namespace _03_XX_CI_CD_Azure_DevOps.Data.Tests.Servicos
{
    public interface IByteBankRepositorio
    {
        public List<Cliente> BuscarClientes();

        public List<Agencia> BuscarAgencias();

        public List<ContaCorrente> BuscarContasCorrentes();
    }
}