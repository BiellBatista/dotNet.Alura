﻿using System;

namespace _03_05_XX_Comparacoes_Objetos.Antes
{
    internal class ClasseBase : IAulaItem
    {
        public void Executar()
        {
            Funcionario3 funcionario = new Funcionario3(1500);
            funcionario.CPF = "123.456.789-00";
            funcionario.Nome = "josé da silva";
            funcionario.DataNascimento = new DateTime(2000, 1, 1);

            ((IFuncionario2)funcionario).CargaHorariaMensal = 168;
            ((IPlantonista2)funcionario).CargaHorariaMensal = 32;
            funcionario.EfeturarPagamento();
            funcionario.CrachaGerado += (s, e) =>
            {
                Console.WriteLine("Crachá gerado");
            };
            ((IFuncionario2)funcionario).GerarCracha();
            ((IPlantonista2)funcionario).GerarCracha();
        }
    }

    internal interface IFuncionario2
    {
        string CPF { get; set; }
        string Nome { get; set; }
        DateTime DataNascimento { get; set; }

        event EventHandler CrachaGerado;

        void GerarCracha();

        decimal Salario { get; }
        int CargaHorariaMensal { get; set; }

        void EfeturarPagamento();
    }

    internal interface IPlantonista2
    {
        int CargaHorariaMensal { get; set; }

        void GerarCracha();
    }

    internal class Funcionario3 : IFuncionario2, IPlantonista2
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public event EventHandler CrachaGerado;

        void IFuncionario2.GerarCracha()
        {
            if (CrachaGerado != null)
            {
                CrachaGerado(this, new EventArgs());
            }
        }

        void IPlantonista2.GerarCracha()
        {
            if (CrachaGerado != null)
            {
                CrachaGerado(this, new EventArgs());
            }
        }

        public decimal Salario { get; }

        int IFuncionario2.CargaHorariaMensal { get; set; }

        int IPlantonista2.CargaHorariaMensal { get; set; }

        public Funcionario3(decimal salario)
        {
            Salario = salario;
        }

        public void EfeturarPagamento()
        {
            Console.WriteLine("Pagamento Efetuado");
        }
    }
}