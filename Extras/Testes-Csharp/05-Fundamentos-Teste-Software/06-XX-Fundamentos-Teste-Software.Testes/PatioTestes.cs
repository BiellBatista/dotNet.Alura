using _06_XX_Fundamentos_Teste_Software.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace _06_XX_Fundamentos_Teste_Software.Testes
{
    public class PatioTestes : IDisposable
    {
        private readonly ITestOutputHelper _saidaConoleTeste;

        private readonly Veiculo _veiculo;

        public PatioTestes(ITestOutputHelper saidaConoleTeste)
        {
            _saidaConoleTeste = saidaConoleTeste;
            _veiculo = new Veiculo();

            _saidaConoleTeste.WriteLine("Construtor invocado.");
        }

        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            //Arrange
            var estacionamento = new Patio();

            _veiculo.Proprietario = "Gabriel Batista";
            _veiculo.Tipo = TipoVeiculo.Automovel;
            _veiculo.Cor = "Verde";
            _veiculo.Modelo = "Fusca";
            _veiculo.Placa = "ASD-9999";

            estacionamento.RegistrarEntradaVeiculo(_veiculo);
            estacionamento.RegistrarSaidaVeiculo(_veiculo.Placa);

            //Act
            var faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Gabriel Batista", "ASD-9999", "Preto", "Gol")]
        [InlineData("Gabriel Almeida", "EFG-0000", "Prata", "Golf")]
        [InlineData("Letícia Baraldi", "CVF-4567", "Vermelho", "Honda Civic")]
        [InlineData("Jose Silva", "QDC-4215", "Branco", "HB20")]
        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();

            _veiculo.Proprietario = proprietario;
            _veiculo.Tipo = TipoVeiculo.Automovel;
            _veiculo.Placa = placa;
            _veiculo.Modelo = modelo;
            _veiculo.Cor = cor;

            estacionamento.RegistrarEntradaVeiculo(_veiculo);
            estacionamento.RegistrarSaidaVeiculo(_veiculo.Placa);

            //Act
            var faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Gabriel Batista", "ASD-9999", "Preto", "Gol")]
        public void LocalicaVeiculoNoPatioComBaseNaIdDoTicket(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();

            _veiculo.Proprietario = proprietario;
            _veiculo.Tipo = TipoVeiculo.Automovel;
            _veiculo.Placa = placa;
            _veiculo.Modelo = modelo;
            _veiculo.Cor = cor;

            estacionamento.RegistrarEntradaVeiculo(_veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(_veiculo.IdTicket);

            //Assert
            Assert.Contains("###Ticket Estacionamento Alura###", consultado.Ticket);
        }

        [Fact]
        public void AlterarDadosDoProprioVeiculo()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculoAlterado = new Veiculo();

            _veiculo.Proprietario = "Gabriel Batista";
            _veiculo.Tipo = TipoVeiculo.Automovel;
            _veiculo.Cor = "Verde";
            _veiculo.Modelo = "Fusca";
            _veiculo.Placa = "ASD-9999";

            estacionamento.RegistrarEntradaVeiculo(_veiculo);

            veiculoAlterado.Proprietario = "Gabriel Almeida";
            veiculoAlterado.Tipo = TipoVeiculo.Automovel;
            veiculoAlterado.Cor = "Preto";
            veiculoAlterado.Modelo = "Fusca";
            veiculoAlterado.Placa = "ASD-9999";

            //Act
            var alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        public void Dispose()
        {
            _saidaConoleTeste.WriteLine("Dispose invocado.");
        }
    }
}