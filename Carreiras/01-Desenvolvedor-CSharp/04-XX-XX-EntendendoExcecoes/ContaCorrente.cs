﻿using System;

namespace _04_XX_XX_EntendendoExcecoes
{
    public class ContaCorrente
    {
        public static double TaxaOperacao { get; private set; }
        public Cliente Titular { get; set; }
        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciaNaoPermitidos { get; private set; }
        public static int TotalDeContasCriadas { get; private set; }
        // o _ serve para destacar que o atributo é privado
        //private int _agencia;
        public int Agencia { get; }
        //o atributo readonly faz com quem o campo seja somente leitura e que apenas o construtor pode atribuir valor
        //private readonly int _numero;
        //com apenas o get, a propriedade se torna apenas leitura (readonly)
        public int Numero { get; }

        private double _saldo = 100; //o _ serve para mostrar que o atributo é privado
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                    return;
                _saldo = value;
            }
        }

        public ContaCorrente(int agencia, int numero)
        {
            if (agencia <= 0)//nameof() {operador que espera o nome de uma classe/argumento/método/propriedade/atributos..} pega o nome do parametro e passa para string
                throw new ArgumentException("O argumento agencia deve ser maior do que 0.", nameof(agencia)); //passando o argumento que deu problema
            //throw new ArgumentException("O argumento agencia deve ser maior do que 0."); //falando tem uma execação de argumento
            //throw new Exception("A agência e o número devem ser maiores que 0");
            if (numero <= 0)
                throw new ArgumentException("O argumento agencia deve ser maior do que 0.", nameof(numero)); //passando o argumento que deu problema
                                                                                                             //throw new ArgumentException("O argumento numero deve ser maior do que 0."); //falando tem uma execação de argumento
                                                                                                             //throw new Exception("A agência e o número devem ser maiores que 0");
            Agencia = agencia;
            Numero = numero;
            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        public void Sacar(double valor)
        {
            if (valor < 0)
                throw new ArgumentException("Valor inválido para o saque", nameof(valor));
            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }
            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }


        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
                throw new ArgumentException("Valor inválido para a transferência", nameof(valor));

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciaNaoPermitidos++;
                //throw; //só psso colocar um throw; vázio em um catch e ele lança a exceção recebida
                throw new OperacaoFinanceiraException("Operação não realizada!", ex);
            }
            contaDestino.Depositar(valor);
        }

        //toda vez que eu executar o objeto sem método, irá invocar o ToString();
        public override string ToString()
        {
            // posso colocar operações de QUALQUER TIPO dentro do {}, como {1 + 2 - 3}
            return $"Número {Numero}, Agência {Agencia}, Saldo {Saldo}";
            //return "Número " + Numero + ", Agência " + Agencia + ", Saldo " + Saldo;
        }
    }
}
