using _02_XX_Integrando_Aplicacao_Banco_Dados.Dados.Contexto;
using System;
using Xunit;

namespace _02_XX_Integrando_Aplicacao_Banco_Dados.Infraestrutura.Testes
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