using _04_XX_TDD_xUnit.Core;
using System;
using Xunit;

namespace _04_XX_TDD_xUnit.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExceptionDadoValorNegatvio()
        {
            //Arranje - Cenário de entrada.
            //Given
            var valorNegativo = -100;

            //Assert - Seção de verificação
            //Then
            Assert.Throws<ArgumentException>(
                //Act - Método que está sendo testado
                //When
                () => new Lance(null, valorNegativo)
           );
        }
    }
}
