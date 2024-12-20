﻿using _02_XX_TDD_xUnit.Core;
using Xunit;

namespace _02_XX_TDD_xUnit.Tests
{
    public class LeilaoTestes
    {
        //[Fact] //Annotation diz que este método é um teste
        //public void LeilaoComVariosLances()
        //{
        //    //Arranje - Cenário de entrada.
        //    var leilao = new Leilao("Van Gogh");
        //    var fulano = new Interessada("Fulano", leilao);
        //    var maria = new Interessada("Maria", leilao);

        //    leilao.RecebeLance(fulano, 800);
        //    leilao.RecebeLance(maria, 900);
        //    leilao.RecebeLance(fulano, 1000);
        //    leilao.RecebeLance(maria, 990);

        //    //Act - Método que está sendo testado
        //    leilao.TerminaPregao();

        //    //Assert - Seção de verificação
        //    var valorEsperado = 1000;
        //    var valorObtido = leilao.Ganhador.Valor;

        //    Assert.Equal(valorEsperado, valorObtido);
        //}

        [Theory] //Transforma este método em uma classe de equivalência
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })] //Indica os dados que esta classe receberá
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })] //Indica os dados que esta classe receberá
        [InlineData(800, new double[] { 800 })] //Indica os dados que esta classe receberá
        public void LeilaoComVariosLances(double valorEsperado, double[] ofertas)
        {
            //Arranje - Cenário de entrada.
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            foreach (var valor in ofertas)
            {
                leilao.RecebeLance(fulano, valor);
            }

            //Act - Método que está sendo testado
            leilao.TerminaPregao();

            //Assert - Seção de verificação
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        //[Fact]
        //public void LeilaoComApenasUmLance()
        //{
        //    //Arranje - Cenário de entrada.
        //    var leilao = new Leilao("Van Gogh");
        //    var fulano = new Interessada("Fulano", leilao);

        //    leilao.RecebeLance(fulano, 800);

        //    //Act - Método que está sendo testado
        //    leilao.TerminaPregao();

        //    //Assert - Seção de verificação
        //    var valorEsperado = 800;
        //    var valorObtido = leilao.Ganhador.Valor;

        //    Assert.Equal(valorEsperado, valorObtido);
        //}

        //[Fact]
        //public void LeilaoComLancesOrdenadosPorValor()
        //{
        //    //Arranje - Cenário de entrada.
        //    var leilao = new Leilao("Van Gogh");
        //    var fulano = new Interessada("Fulano", leilao);
        //    var maria = new Interessada("Maria", leilao);

        //    leilao.RecebeLance(fulano, 800);
        //    leilao.RecebeLance(maria, 900);
        //    leilao.RecebeLance(maria, 990);
        //    leilao.RecebeLance(fulano, 1000);

        //    //Act - Método que está sendo testado
        //    leilao.TerminaPregao();

        //    //Assert - Seção de verificação
        //    var valorEsperado = 1000;
        //    var valorObtido = leilao.Ganhador.Valor;

        //    Assert.Equal(valorEsperado, valorObtido);
        //}

        //[Fact]
        //public void LeilaoComTresClientes()
        //{
        //    //Arranje - Cenário de entrada.
        //    //Given - Dado leilão com três clientes e lances realizados por eles
        //    var leilao = new Leilao("Van Gogh");
        //    var fulano = new Interessada("Fulano", leilao);
        //    var maria = new Interessada("Maria", leilao);
        //    var beltrano = new Interessada("Beltrano", leilao);

        //    leilao.RecebeLance(fulano, 800);
        //    leilao.RecebeLance(maria, 900);
        //    leilao.RecebeLance(fulano, 1000);
        //    leilao.RecebeLance(maria, 990);
        //    leilao.RecebeLance(beltrano, 1400);

        //    //Act - Método que está sendo testado
        //    //When - Quando o pregão/leilão termina
        //    leilao.TerminaPregao();

        //    //Assert - Seção de verificação
        //    //Then - Então o valor esperado é o maior lance dado pelo cliente
        //    var valorEsperado = 1400;
        //    //Assert - Seção de verificação
        //    //Then - Então o cliente ganhador é o que deu o maior o lance
        //    var valorObtido = leilao.Ganhador.Valor;

        //    Assert.Equal(valorEsperado, valorObtido);
        //    Assert.Equal(beltrano, leilao.Ganhador.Cliente);
        //}

        [Fact]
        public void LeilaoSemLances()
        {
            //Arranje - Cenário de entrada.
            var leilao = new Leilao("Van Gogh");

            //Act - Método que está sendo testado
            leilao.TerminaPregao();

            //Assert - Seção de verificação
            var valorEsperado = 0;
            var valorObtido = leilao.Ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}

/**
 * Portanto, se queremos passar dados de entrada para orientar os testes através de [InlineData], usamos a anotação [Theory].
 * Se não importar quais dados são passados e a expectativa permanecer a mesma, usamos [Fact].
 */