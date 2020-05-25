using _01_XX_TDD_xUnit.Core;
using Xunit;

namespace _02_XX_TDD_xUnit.Tests
{
    public class LeilaoTestes
    {
        [Fact] //Annotation diz que este método é um teste
        public void LeilaoComVariosLances()
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
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LeilaoComApenasUmLance()
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

            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
