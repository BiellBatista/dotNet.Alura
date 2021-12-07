using _01_XX_Fundamentos_Teste_Software.Modelos;
using Xunit;

namespace _01_XX_Fundamentos_Teste_Software.Testes
{
    public class VeiculoTestes
    {
        [Fact]
        public void TestaVeiculoAcelerar()
        {
            var veiculo = new Veiculo();
            veiculo.Acelerar(10);

            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrear()
        {
            var veiculo = new Veiculo();
            veiculo.Frear(10);

            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }
    }
}