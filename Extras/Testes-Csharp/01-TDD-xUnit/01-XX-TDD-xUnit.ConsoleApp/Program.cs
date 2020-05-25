using _01_XX_TDD_xUnit.Core;
using System;

namespace _01_XX_TDD_xUnit.ConsoleApp
{
    class Program
    {
        private static void Verifica(double esperado, double obtido)
        {
            var cor = Console.ForegroundColor;

            if (esperado == obtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("TESTE OK");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"TESTE FALHOU! Esperado: {esperado}, obtido: {obtido}");
            }

            Console.ForegroundColor = cor;
        }

        private static void LeilaoComVariosLances()
        {
            //Arranje - Cenário de entrada.
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 990);

            //Act - Método que está sendo testado
            leilao.TerminaPregao();

            //Assert - Seção de verificação
            var valorEsperado = 1200;
            var valorObtido = leilao.Ganhador.Valor;

            Verifica(valorEsperado, valorObtido);
        }

        private static void LeilaoComApenasUmLance()
        {
            //Arranje - Cenário de entrada.
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            leilao.RecebeLance(fulano, 800);

            //Act - Método que está sendo testado
            leilao.TerminaPregao();

            //Assert - Seção de verificação
            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;

            Verifica(valorEsperado, valorObtido);
        }

        static void Main()
        {
            LeilaoComVariosLances();
            LeilaoComApenasUmLance();

            Console.ReadLine();
        }
    }
}
