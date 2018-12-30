using System;

namespace _04_XX_XX_EntendendoExcecoes
{
    public class ContaCorrente
    {
        public static double TaxaOperacao { get; private set; }
        public Cliente Titular { get; set; }
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
            TaxaOperacao = 30 / TotalDeContasCriadas;

            TotalDeContasCriadas++;
        }

        public bool Sacar(double valor)
        {
            if (_saldo < valor)
                return false;
            _saldo -= valor;
            return true;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }


        public bool Transferir(double valor, ContaCorrente contaDestino)
        {
            if (_saldo < valor)
                return false;
            _saldo -= valor;
            contaDestino.Depositar(valor);
            return true;
        }
    }
}
