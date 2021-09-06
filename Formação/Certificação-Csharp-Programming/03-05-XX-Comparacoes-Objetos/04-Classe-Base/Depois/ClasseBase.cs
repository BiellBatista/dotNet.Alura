using System;

namespace _03_05_XX_Comparacoes_Objetos.Depois
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

            Cliente cliente = new Cliente
            {
                CPF = "789.456.123-99",
                DataNascimento = new DateTime(1980, 1, 2),
                Nome = "Maria de Souza",
                DataUltimaCompra = new DateTime(2018, 1, 1),
                ValorUltimaCompra = 200
            };

            Console.WriteLine(cliente);

            Pessoa pessoa = new Cliente
            {
                CPF = "789.456.123-99",
                DataNascimento = new DateTime(1980, 1, 2),
                Nome = "Maria de Souza",
            };
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

    internal class Funcionario3 : Pessoa, IFuncionario2, IPlantonista2
    {
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

    internal class Cliente : Pessoa
    {
        public DateTime? DataUltimaCompra { get; set; }
        public decimal? ValorUltimaCompra { get; set; }

        public override string ToString()
        {
            return $"Nome: {Nome}, Data última compra {DataUltimaCompra}";
        }
    }

    internal class ClienteFilha : Cliente
    {
    }

    internal class ClienteNeta : ClienteFilha
    {
    }

    internal abstract class Pessoa
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}