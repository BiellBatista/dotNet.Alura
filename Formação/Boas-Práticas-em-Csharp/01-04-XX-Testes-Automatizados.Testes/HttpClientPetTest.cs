using _01_04_XX_Testes_Automatizados.Console.Servicos;

namespace _01_04_XX_Testes_Automatizados.Testes;

public class HttpClientPetTest
{
    [Fact]
    public async Task ListaPetsDeveRetornarUmaListaNaoVazia()
    {
        //Arrange
        var clientePet = new HttpClientPet();

        //Act
        var lista = await clientePet.ListPetsAsync();

        //Assert
        Assert.NotNull(lista);
        Assert.NotEmpty(lista);
    }

    [Fact]
    public async Task QuandoAPIForaDeveRetornarUmaExcecao()
    {
        //Arrange
        var clientePet = new HttpClientPet(uri: "http://localhost:1111");

        //Act - Assert
        await Assert.ThrowsAnyAsync<Exception>(() => clientePet.ListPetsAsync());
    }
}