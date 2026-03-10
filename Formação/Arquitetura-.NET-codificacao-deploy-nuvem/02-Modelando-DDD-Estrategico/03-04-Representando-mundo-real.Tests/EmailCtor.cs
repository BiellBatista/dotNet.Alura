using _03_04_Representando_mundo_real.API.Domain;

namespace _03_04_Representando_mundo_real.Tests;

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