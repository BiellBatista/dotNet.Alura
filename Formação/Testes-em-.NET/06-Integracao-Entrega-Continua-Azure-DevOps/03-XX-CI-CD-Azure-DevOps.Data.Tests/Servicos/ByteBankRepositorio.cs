﻿using _03_XX_CI_CD_Azure_DevOps.Domain.Entidades;

namespace _03_XX_CI_CD_Azure_DevOps.Data.Tests.Servicos
{
    internal class ByteBankRepositorio : IByteBankRepositorio
    {
        private List<Cliente> clientes = new List<Cliente>()
        {
            new Cliente
            {
              Nome = "Bruce Kent",
              CPF = "486.074.980-45",
              Identificador = Guid.NewGuid(),
              Profissao = "Empresário",
              Id = 1
            },
            new Cliente
            {
              Nome = "Marta Silva",
              CPF = "877.288.430-44",
              Identificador = Guid.NewGuid(),
              Profissao = "Agente de Viagens",
              Id = 2
            },
            new Cliente
            {
              Nome = "Hélio Lopes",
              CPF = "743.062.450-20",
              Identificador = Guid.NewGuid(),
              Profissao = "Jogador de Poker Profissional",
              Id = 3
            }
        };

        public List<Cliente> Clientes
        { get { return clientes; } }

        private List<Agencia> agencias = new List<Agencia>()
        {
            new Agencia()
            {
                Nome = "Agencia Central 1",
                Identificador = Guid.NewGuid(),
                Id = 1,
                Endereco= "Rua das Flores,25",
                Numero=147
            },
            new Agencia()
            {
                Nome = "Agencia Central 2",
                Identificador = Guid.NewGuid(),
                Id = 2,
                Endereco= "Rua Gomes de Freitas,418",
                Numero=852
            },
            new Agencia()
            {
                Nome = "Agencia Central 3",
                Identificador = Guid.NewGuid(),
                Id = 3,
                Endereco= "Av. Gumercindo Avides,13",
                Numero=349
            }
        };

        public List<Agencia> Agencias
        { get { return agencias; } }

        private List<ContaCorrente> contas = new List<ContaCorrente>()
        {
            new ContaCorrente()
            {
                Saldo = 10,
                Id = 1,
                Identificador = Guid.NewGuid(),
                Cliente = new Cliente(){
                      Nome = "Bruce Kent",
                      CPF = "486.074.980-45",
                      Identificador = Guid.NewGuid(),
                      Profissao = "Empresário",
                      Id = 1
                },
                Agencia = new Agencia(){
                     Nome = "Agencia Central 1",
                     Identificador = Guid.NewGuid(),
                     Id = 1,
                     Endereco= "Rua das Flores,25",
                     Numero=147
                }
            },
            new ContaCorrente()
            {
                Saldo = 10,
                Id = 2,
                Identificador = Guid.NewGuid(),
                Cliente = new Cliente(){
                      Nome = "Marta Silva",
                      CPF = "877.288.430-44",
                      Identificador = Guid.NewGuid(),
                      Profissao = "Agente de Viagens",
                      Id = 2
                },
                Agencia = new Agencia(){
                    Nome = "Agencia Central 2",
                    Identificador = Guid.NewGuid(),
                    Id = 2,
                    Endereco= "Rua Gomes de Freitas,418",
                    Numero=852
                }
            }
        };

        public List<ContaCorrente> Contas
        { get { return contas; } }

        public bool AdicionarConta(ContaCorrente conta)
        {
            try
            {
                Contas.Add(conta);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AdicionarAgencia(Agencia agencia)
        {
            try
            {
                Agencias.Add(agencia);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AdicionarCliente(Cliente cliente)
        {
            try
            {
                Clientes.Add(cliente);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Agencia> BuscarAgencias()
        {
            return Agencias;
        }

        public List<Cliente> BuscarClientes()
        {
            return Clientes;
        }

        public List<ContaCorrente> BuscarContasCorrentes()
        {
            return Contas;
        }
    }
}