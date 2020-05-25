using _04_XX_TDD_xUnit.Core;
using Xunit;

namespace _04_XX_TDD_xUnit.Tests
{
    public class LeilaoTerminaPregao
    {
        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(double valorEsperado, double[] ofertas)
        {
            //Arranje - Cenário de entrada.
            //Given - Dado leilão com três clientes e lances realizados por eles
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];

                if (i % 2 == 0)
                {
                    leilao.RecebeLance(fulano, valor);
                }
                else
                {
                    leilao.RecebeLance(maria, valor);
                }
            }

            //Act - Método que está sendo testado
            //When - Quando o pregão/leilão termina
            leilao.TerminaPregao();

            //Assert - Seção de verificação
            //Then - Então o cliente ganhador é o que deu o maior o lance
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            //Arranje - Cenário de entrada.
            //Given - Dado leilão com três clientes e lances realizados por eles
            var leilao = new Leilao("Van Gogh");

            //Act - Método que está sendo testado
            //When - Quando o pregão/leilão termina
            leilao.TerminaPregao();

            //Assert - Seção de verificação
            //Then - Então o cliente ganhador é o que deu o maior o lance
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
