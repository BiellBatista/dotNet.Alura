using System;

namespace _01_01_XX_Coesao_S
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculadora = new CalculadoraDeSalario();
            var funcionario = new Funcionario(new Desenvolvedor(new DezOuVintePorcento()), 2000);

            double resultado = calculadora.Calcular(funcionario);

            Console.WriteLine("O salario de um desenvolvedor que ganha 2000 bruto eh: " + resultado);
            Console.ReadKey();
        }
    }
}

/**
 * Podemos pensar sobre coesão em vários níveis diferentes. Por exemplo, o que seria uma interface coesa? Uma interface coesa é aquela que também
 * só possui uma única responsabilidade.

E será que conseguimos ver a coesão pelo outro lado? Pense, se a classe A depende de B, idealmente B deve prover uma interface para A, somente
    com as coisas que A depende. Ou seja, a classe não deve depender de métodos que ela não usa. Isso é o que chamamos de Princípio de Segregação
    de Interfaces, ou ISP.
 */
