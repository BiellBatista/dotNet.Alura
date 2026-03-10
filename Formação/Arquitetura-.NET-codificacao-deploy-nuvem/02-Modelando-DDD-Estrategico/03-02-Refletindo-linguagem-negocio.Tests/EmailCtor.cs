using _03_02_Refletindo_linguagem_negocio.API.Domain;

namespace _03_02_Refletindo_linguagem_negocio.Tests;

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