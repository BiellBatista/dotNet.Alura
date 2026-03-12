using _05_05_Camada_anticorrupcao.Clientes.Cadastro;

namespace _05_05_Camada_anticorrupcao.Tests;

public class EmailCtor
{
    [Fact]
    public void Deve_Lancar_ArgumentException_Quando_Valor_Invalido()
    {
        // arrange
        string emailInvalido = "valor qualquer";

        // act & assert
        Assert.Throws<ArgumentException>(() => new Email(emailInvalido));
    }
}