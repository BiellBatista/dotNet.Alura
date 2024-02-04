using _03_01_XX_Importando_Json.Console.Servicos.Arquivos;

namespace _03_01_XX_Importando_Json.Testes.Servicos;

public class LeitorDeArquivoFactoryTest
{
    [Fact]
    public void QuantoExtensaoForCsvDeveRetornarTipoLeitorDeArquivoCsv()
    {
        // arrange
        string caminhoArquivo = "pets.csv";

        // act
        var leitor = LeitorDeArquivosFactory.CreatePetFrom(caminhoArquivo);

        // assert
        Assert.IsType<LeitorDeArquivoCsv>(leitor);
    }

    [Fact]
    public void QuantoExtensaoForJsonDeveRetornarTipoLeitorDeArquivoJson()
    {
        // arrange
        string caminhoArquivo = "pets.json";

        // act
        var leitor = LeitorDeArquivosFactory.CreatePetFrom(caminhoArquivo);

        // assert
        Assert.IsType<LeitorDeArquivosJson>(leitor);
    }

    [Fact]
    public void QuantoExtensaoNaoSuportadaDeveRetornarNulo()
    {
        // arrange
        string caminhoArquivo = "pets.xsl";

        // act
        var leitor = LeitorDeArquivosFactory.CreatePetFrom(caminhoArquivo);

        // assert
        Assert.Null(leitor);
    }
}