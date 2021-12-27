using _02_XX_Fundamentos_Teste_Software.Modelos;
using Xunit;

namespace _02_XX_Fundamentos_Teste_Software.Testes
{
    public class VeiculoTestes
    {
        //alterando o nome que ficará visível no gerenciador de testes
        [Fact(DisplayName = "Teste nº1")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste nº2")]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrear()
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Frear(10);

            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste nº3")]
        public void TestaTipoVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act

            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        //ignorando o teste de unidade
        [Fact(DisplayName = "Teste nº4", Skip = "Teste ainda não implementado. Ignorar")]
        public void ValidaNomeProprietario()
        {
        }

        [Theory]
        [ClassData(typeof(Veiculo))]
        public void TestaVeiculoClass(Veiculo modelo)
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);
            modelo.Acelerar(10);

            //Assert
            Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
        }
    }
}