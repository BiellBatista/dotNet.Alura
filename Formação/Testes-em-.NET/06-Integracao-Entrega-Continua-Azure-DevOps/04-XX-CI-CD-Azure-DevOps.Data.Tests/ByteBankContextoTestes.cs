using _04_XX_CI_CD_Azure_DevOps.Data.Contexto;
using Xunit;

namespace _04_XX_CI_CD_Azure_DevOps.Data.Tests
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