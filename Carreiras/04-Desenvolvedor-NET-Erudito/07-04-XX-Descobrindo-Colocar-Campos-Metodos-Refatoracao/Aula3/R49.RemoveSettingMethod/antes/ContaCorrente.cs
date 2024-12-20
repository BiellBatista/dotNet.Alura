﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_04_XX_Descobrindo_Colocar_Campos_Metodos_Refatoracao.Aula3.R49.RemoveSettingMethod.antes
{
    class ContaCorrente
    {
        private static int ultimoId = 0;
        private int id;
        private decimal saldo;

        public ContaCorrente(decimal saldo)
        {
            this.id = GetNewId();
            this.saldo = saldo;
        }

        public void SetSaldo(decimal saldo)
        {
            this.saldo = saldo;
        }

        private static int GetNewId()
        {
            return ultimoId++;
        }

        private void Depositar(decimal valor)
        {
            saldo += valor;
        }

        private void Sacar (decimal valor)
        {
            if (valor > saldo)
            {
                throw new ArgumentException("Saldo insuficiente.");
            }
            saldo -= valor;
        }
    }
}
