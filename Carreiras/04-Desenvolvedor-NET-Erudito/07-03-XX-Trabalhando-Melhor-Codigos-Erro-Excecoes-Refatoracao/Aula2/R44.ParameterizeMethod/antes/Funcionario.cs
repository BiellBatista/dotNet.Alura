﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _07_03_XX_Trabalhando_Melhor_Codigos_Erro_Excecoes_Refatoracao.R44.ParameterizeMethod.antes
{
    class Program
    {
        void Main()
        {
            var funcionario1 = new Funcionario("Tony Estarque", 10000);
            var funcionario2 = new Funcionario("Pedro Parques", 2000);

            funcionario1.DarAumentoDe5PorCento();
            funcionario2.DarAumentoDe10PorCento();
        }
    }

    class Funcionario
    {
        readonly string nome;
        public string Nome => nome;

        decimal salario;
        public decimal Salario => salario;

        public Funcionario(string nome, decimal salario)
        {
            this.nome = nome;
            this.salario = salario;
        }

        public void DarAumentoDe5PorCento()
        {
            salario *= 1.05m;
        }

        public void DarAumentoDe10PorCento()
        {
            salario *= 1.10m;
        }
    }
}
