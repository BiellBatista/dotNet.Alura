using _05_04_Implementando_caso_uso.Domain.Models;

namespace _05_04_Implementando_caso_uso.Testes;

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