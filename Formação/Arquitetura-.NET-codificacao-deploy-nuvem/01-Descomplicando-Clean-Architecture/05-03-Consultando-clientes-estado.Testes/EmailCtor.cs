using _05_03_Consultando_clientes_estado.Domain.Models;

namespace _05_03_Consultando_clientes_estado.Testes;

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