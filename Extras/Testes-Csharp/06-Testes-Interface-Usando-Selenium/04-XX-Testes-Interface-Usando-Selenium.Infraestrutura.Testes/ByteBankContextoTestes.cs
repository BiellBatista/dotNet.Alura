using _04_XX_Testes_Interface_Usando_Selenium.Dados.Contexto;
using System;
using Xunit;

namespace _04_XX_Testes_Interface_Usando_Selenium.Infraestrutura.Testes
{
    public class ByteBankContextoTestes
    {
        [Fact]
        public void TestaConexaoContextoComBDMySQL()
        {
            //Arrange
            var contexto = new ByteBankContexto();
            bool conectado = default;

            //Act
            try
            {
                conectado = contexto.Database.CanConnect();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível conectar a base de dados.");
            }

            Assert.True(conectado);
        }
    }
}