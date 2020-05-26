using Xunit;
using _05_XX_TDD_xUnit.Core;
using System.Linq;

namespace _05_XX_TDD_xUnit.Tests
{
    public class LeilaoRecebeLance
    {
        [Theory]
        [InlineData(2, new double[] { 800, 900 })]
        [InlineData(4, new double[] { 1000, 1200, 1400, 100 })]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(int qtdeEsperada, double[] ofertas)
        {
            //Arranje - Cenário de entrada.
            //Given - Dado leilão com dois clientes e lances realizados por eles
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

            leilao.TerminaPregao();

            //Act - Método que está sendo testado
            //When - Quando o pregão/leilão termina
            leilao.RecebeLance(fulano, 1000);

            //Assert - Seção de verificação
            //Then - Então o cliente ganhador é o que deu o maior o lance
            var qtdeObtida = leilao.Lances.Count();

            Assert.Equal(qtdeEsperada, qtdeObtida);
        }

        [Theory]
        [InlineData(new double[] { 200, 300, 400, 500 })]
        [InlineData(new double[] { 200 })]
        [InlineData(new double[] { 200, 300, 400 })]
        [InlineData(new double[] { 200, 300, 400, 500, 600, 700 })]
        public void QtdePermaneceZeroDadoQuePregaoNaoFoiIniciado(double[] ofertas)
        {
            //Arranje - Cenário de entrada.
            //Given - Dado leilão com três clientes e lances realizados por eles
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano de Tal", leilao);

            //Act - Método que está sendo testado
            //When - Quando o pregão/leilão termina
            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
            }

            //Assert - Seção de verificação
            //Then - Então o cliente ganhador é o que deu o maior o lance
            Assert.Empty(leilao.Lances);
        }

        [Fact]
        public void NaoAceitaProximoLanceDadoMesmoClienteRealizouUltimoLance()
        {
            //Arranje - Cenário de entrada.
            //Given - Dado leilão com três clientes e lances realizados por eles
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            leilao.IniciaPregao();
            leilao.RecebeLance(fulano, 800);

            //Act - Método que está sendo testado
            //When - Quando o pregão/leilão termina
            leilao.RecebeLance(fulano, 1000);

            //Assert - Seção de verificação
            //Then - Então o cliente ganhador é o que deu o maior o lance
            leilao.TerminaPregao();
            var qtdeEsperada = 1;
            var qtdeObtida = leilao.Lances.Count();

            Assert.Equal(qtdeEsperada, qtdeObtida);
        }
    }
}
