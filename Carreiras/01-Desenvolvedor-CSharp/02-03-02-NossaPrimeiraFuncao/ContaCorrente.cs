﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_03_02_NossaPrimeiraFuncao
{
    class ContaCorrente
    {
        public string titular;
        public int agencia;
        public int numero;
        public double saldo = 100;

        public bool Sacar(double valor)
        {
            if (this.saldo < valor)
                return false;
            this.saldo -= valor;
            return true;
        }

        public void Depositar(double valor)
        {
            if (valor > 0)
                this.saldo += valor;
        }

        public bool Transferir(double valor, ContaCorrente contaDestino)
        {
            if (this.saldo < valor)
                return false;
            this.saldo -= valor;
            contaDestino.Depositar(valor);
            return true;
        }
    }
}
