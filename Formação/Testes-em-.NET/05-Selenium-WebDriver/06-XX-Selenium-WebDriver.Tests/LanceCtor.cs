using _06_XX_Selenium_WebDriver.Core;
using Xunit;

namespace _06_XX_Selenium_WebDriver.Tests
{
    [Trait("Tipo", "Unidade")]
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExceptionDadoValorNegativo()
        {
            //Arranje
            var valorNegativo = -100;

            //Assert
            Assert.Throws<System.ArgumentException>(
                //Act
                () => new Lance(null, valorNegativo)
            );
        }

    }
}
