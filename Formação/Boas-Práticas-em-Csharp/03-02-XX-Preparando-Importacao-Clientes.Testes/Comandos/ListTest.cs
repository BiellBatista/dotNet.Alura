using _03_02_XX_Preparando_Importacao_Clientes.Console.Modelos;
using _03_02_XX_Preparando_Importacao_Clientes.Console.Results;
using _03_02_XX_Preparando_Importacao_Clientes.Testes.Builder;

namespace _03_02_XX_Preparando_Importacao_Clientes.Testes.Comandos;

public class ListTest
{
    [Fact]
    public async Task QuandoExecutarComandoListDeveRetornarListaDePets()
    {
        //Arrange
        List<Pet>? listaDePet = new();
        var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"),
                          "Lima", TipoPet.Cachorro);
        listaDePet.Add(pet);

        var httpClientPet = HttpClientPetMockBuilder.GetMockList(listaDePet);

        //Act
        var retorno = await new Console.Comandos.List(httpClientPet.Object)
            .ExecutarAsync();

        //Assert
        var resultado = (SuccessWithPets)retorno.Successes[0];
        Assert.Single(resultado.Data);
    }
}