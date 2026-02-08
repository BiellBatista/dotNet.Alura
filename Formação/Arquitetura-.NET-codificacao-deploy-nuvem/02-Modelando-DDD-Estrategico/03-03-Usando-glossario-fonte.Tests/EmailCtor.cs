using _03_03_Usando_glossario_fonte.API.Domain;

namespace _03_03_Usando_glossario_fonte.Tests;

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