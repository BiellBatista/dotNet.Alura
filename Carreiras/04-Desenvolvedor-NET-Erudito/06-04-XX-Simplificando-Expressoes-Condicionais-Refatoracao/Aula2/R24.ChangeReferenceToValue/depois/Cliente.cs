﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06_04_XX_Simplificando_Expressoes_Condicionais_Refatoracao.R24.ChangeReferenceToValue.depois
{
    class Programa
    {
        public void Main()
        {
            Cliente joao = new Cliente("João Snow");
            joao.DataNascimento = new DateTime(1985, 1, 1);
        }
    }

    class Cliente
    {
        private readonly string nome;
        public string Nome { get => nome; }

        private DateTime dataNascimento;
        public DateTime DataNascimento
        { get => dataNascimento; set => dataNascimento = value; }

        public Cliente(string nome)
        {
            this.nome = nome;
        }
    }
}
