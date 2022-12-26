using _02_XX_Testes_Interface_Usando_Selenium.Dados.Contexto;
using System;
using Xunit;

namespace _02_XX_Testes_Interface_Usando_Selenium.Infraestrutura.Testes
{
    public class ByteBankContextoTestes
    {
        [Fact]
        public void TestaConexaoContextoComBDMySQL()
        {
            //Arrange
            var contexto = new ByteBankContexto();
            bool conectado;
            //Act
            try
            {
                conectado = contexto.Database.CanConnect();
            }
            catch (Exception e)
            {
                throw new Exception($"Não foi possível conectar a base de dados.[{e.Message}]");
            }
            //Assert
            Assert.True(conectado);
        }
    }
}