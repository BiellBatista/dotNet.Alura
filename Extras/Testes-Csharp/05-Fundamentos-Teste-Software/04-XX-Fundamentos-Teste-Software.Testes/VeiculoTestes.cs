using _04_XX_Fundamentos_Teste_Software.Modelos;
using Xunit;

namespace _04_XX_Fundamentos_Teste_Software.Testes
{
    public class VeiculoTestes
    {
        //alterando o nome que ficar� vis�vel no gerenciador de testes
        [Fact]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrearComParametro10()
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Frear(10);

            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaTipoVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act

            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        //ignorando o teste de unidade
        [Fact(Skip = "Teste ainda n�o implementado. Ignorar")]
        public void ValidaNomeProprietarioDoVeiculo()
        {
        }

        [Theory]
        [ClassData(typeof(Veiculo))]
        public void FichaDeInformacaoDoVeiculo(Veiculo modelo)
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);
            modelo.Acelerar(10);

            //Assert
            Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void DadosVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();

            veiculo.Proprietario = "Gabriel Batista";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "ASD-9999";

            //Act
            var dados = veiculo.ToString();

            //Assert
            Assert.Contains("Tipo do Ve�culo: Automovel", dados);
        }
    }
}