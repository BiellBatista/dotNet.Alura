using _06_XX_Fundamentos_Teste_Software.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace _06_XX_Fundamentos_Teste_Software.Testes
{
    public class VeiculoTestes : IDisposable
    {
        private readonly ITestOutputHelper _saidaConoleTeste;

        private readonly Veiculo _veiculo;

        public VeiculoTestes(ITestOutputHelper saidaConoleTeste)
        {
            _saidaConoleTeste = saidaConoleTeste;
            _veiculo = new Veiculo();

            _saidaConoleTeste.WriteLine("Construtor invocado.");
        }

        //alterando o nome que ficará visível no gerenciador de testes
        [Fact]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange

            //Act
            _veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, _veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrearComParametro10()
        {
            //Arrange

            //Act
            _veiculo.Frear(10);

            //Assert
            Assert.Equal(-150, _veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaTipoVeiculo()
        {
            //Arrange

            //Act

            //Assert
            Assert.Equal(TipoVeiculo.Automovel, _veiculo.Tipo);
        }

        //ignorando o teste de unidade
        [Fact(Skip = "Teste ainda não implementado. Ignorar")]
        public void ValidaNomeProprietarioDoVeiculo()
        {
        }

        [Theory]
        [ClassData(typeof(Veiculo))]
        public void FichaDeInformacaoDoVeiculo(Veiculo modelo)
        {
            //Arrange

            //Act
            _veiculo.Acelerar(10);
            modelo.Acelerar(10);

            //Assert
            Assert.Equal(modelo.VelocidadeAtual, _veiculo.VelocidadeAtual);
        }

        [Fact]
        public void DadosVeiculo()
        {
            //Arrange
            _veiculo.Proprietario = "Gabriel Batista";
            _veiculo.Tipo = TipoVeiculo.Automovel;
            _veiculo.Cor = "Verde";
            _veiculo.Modelo = "Fusca";
            _veiculo.Placa = "ASD-9999";

            //Act
            var dados = _veiculo.ToString();

            //Assert
            Assert.Contains("Tipo do Veículo: Automovel", dados);
        }

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
        {
            //Arrange
            var nomeProprietario = "AB";

            //Assert
            Assert.Throws<FormatException>(
                //Act
                () => new Veiculo(nomeProprietario)
            );
        }

        [Fact]
        public void TestaMensagemDeExcecaoDoQuartoCaractereDaPlaca()
        {
            //Arrange
            var placa = "ASDF9999";

            //Assert
            var mensagem = Assert.Throws<FormatException>(
                //Act
                () => new Veiculo().Placa = placa
            );

            //Assert
            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }

        public void Dispose()
        {
            _saidaConoleTeste.WriteLine("Dispose invocado.");
        }
    }
}