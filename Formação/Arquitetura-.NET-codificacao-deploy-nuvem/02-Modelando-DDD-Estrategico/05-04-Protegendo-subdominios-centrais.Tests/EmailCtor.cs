using _05_04_Protegendo_subdominios_centrais.Clientes.Cadastro;

namespace _05_04_Protegendo_subdominios_centrais.Tests;

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