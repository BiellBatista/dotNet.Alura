using System;

namespace _03_04_XX_Classe_Base.Depois
{
    internal class InterfacesExplicitas : IAulaItem
    {
        public void Executar()
        {
            /// <image url="$(ProjectDir)\Cracha.png" />
            /// < image url="$(ProjectDir)\Cracha2.png" />
            Funcionario2 funcionario = new Funcionario2(1500);
            funcionario.CPF = "123.456.789-00";
            funcionario.Nome = "josé da silva";
            funcionario.DataNascimento = new DateTime(2000, 1, 1);

            /**
             * Quando coloca uma impelemntação explicita de uma interface em uma classe, devo realizar casting
             * nos membros que são compartilhados entre as interfaces
             */
            ((IFuncionario)funcionario).CargaHorariaMensal = 168;
            ((IPlantonista)funcionario).CargaHorariaMensal = 32;
            funcionario.EfeturarPagamento();
            funcionario.CrachaGerado += (s, e) =>
            {
                Console.WriteLine("Crachá gerado");
            };
            ((IFuncionario)funcionario).GerarCracha();
            ((IPlantonista)funcionario).GerarCracha();
        }
    }

    internal interface IFuncionario
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

    internal interface IPlantonista
    {
        int CargaHorariaMensal { get; set; }

        void GerarCracha();
    }

    internal class Funcionario2 : IFuncionario, IPlantonista
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public event EventHandler CrachaGerado;

        //quando eu tenho uma implementação de um membro de uma interface explicita, não posso ter o modificador public
        void IPlantonista.GerarCracha()
        {
            if (CrachaGerado != null)
            {
                CrachaGerado(this, new EventArgs());
            }
        }

        //quando eu tenho uma implementação de um membro de uma interface explicita, não posso ter o modificador public
        void IFuncionario.GerarCracha()
        {
            if (CrachaGerado != null)
            {
                CrachaGerado(this, new EventArgs());
            }
        }

        public decimal Salario { get; }

        //quando eu tenho uma implementação de um membro de uma interface explicita, não posso ter o modificador public
        int IPlantonista.CargaHorariaMensal { get; set; }

        //quando eu tenho uma implementação de um membro de uma interface explicita, não posso ter o modificador public
        int IFuncionario.CargaHorariaMensal { get; set; }

        public Funcionario2(decimal salario)
        {
            Salario = salario;
        }

        public void EfeturarPagamento()
        {
            Console.WriteLine("Pagamento Efetuado");
        }
    }
}