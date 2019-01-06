using System;

namespace _05_XX_XX_BibliotecasDLLs.Modelos
{
    /// <summary>
    /// Define uma Conta Corrente do Banco.
    /// </summary>
    public class ContaCorrente : IComparable
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

        /// <summary>
        /// Este construtor cria uma instância de ContaCorrente com os argumentos utilizados.
        /// </summary>
        /// <param name="agencia">Representa o valor da propriedade <see cref="Agencia"/> e deve possuir um valor maior que zero.</param>
        /// <param name="numero">Representa o valor da propriedade <see cref="Numero"/> e deve possuir um valor maior que zero.</param>
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

        /// <summary>
        /// Realiza o saque e atualiza o valor da propriedade <see cref="Saldo"/>.
        /// </summary>
        /// <exception cref="ArgumentException">Exceção lançada quando um valor negativo é utilizado no argumento <paramref name="valor"/>.</exception>
        /// <exception cref="SaldoInsuficienteException">Exceção lançada quando o valor de <paramref name="valor"/> é maior que o valor da propriedade <see cref="Saldo"/></exception>
        /// <param name="valor">Representa o valor do saque, deve ser maior que zero e menor que o <see cref="Saldo"/>.</param>
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

        public override bool Equals(object obj)
        {
            ContaCorrente outraConta = obj as ContaCorrente; //convertendo o obj para contacorrente, caso o obj for uma generalização da ContaCorrente

            if (outraConta == null)
                return false;
            return Numero == outraConta.Numero && Agencia == outraConta.Agencia;
        }

        public int CompareTo(object obj)
        {
            // Retornar negativo quando a instância prece o obj
            // Retornar zero quando a instância e o obj são equivalentes
            // Retornar positivo diferente de zero quando a precedencia for de obj

            var outraConta = obj as ContaCorrente;

            if (outraConta == null)
                return -1;
            else if (Numero < outraConta.Numero)
                return -1;
            else if (Numero == outraConta.Numero)
                return 0;
            else
                return 1;
        }
    }
}
