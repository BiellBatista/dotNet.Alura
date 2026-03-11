using _05_03_Separando_contexto_clientes.Clientes.Cadastro;

namespace _05_03_Separando_contexto_clientes.Tests;

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