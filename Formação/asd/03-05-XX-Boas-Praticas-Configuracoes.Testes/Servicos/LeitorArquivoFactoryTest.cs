using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Arquivos;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Testes.Servicos;

public class LeitorArquivoFactoryTest
{
    [Fact]
    public void QuandoExtensaoCsvDeveRetornarTipoAdequado()
    {
        // arrange
        string caminhoDoArquivo = "lista.csv";

        // act
        var leitor = LeitorDeArquivoFactory.CreateLeitorDePets(caminhoDoArquivo);

        // assert
        Assert.NotNull(leitor);
        Assert.IsType<PetsDoCsv>(leitor);
    }

    [Fact]
    public void QuandoExtensaoCsvDeveRetornarClientesDoCsv()
    {
        // arrange
        string caminhoDoArquivo = "lista.csv";

        // act
        var leitor = LeitorDeArquivoFactory.CreateLeitorDeClientes(caminhoDoArquivo);

        // assert
        Assert.NotNull(leitor);
        Assert.IsType<ClientesDoCsv>(leitor);
    }

    [Fact]
    public void QuandoExtensaoJsonDeveRetornarClientesDoJson()
    {
        // arrange
        string caminhoDoArquivo = "lista.json";

        // act
        var leitor = LeitorDeArquivoFactory.CreateLeitorDeClientes(caminhoDoArquivo);

        // assert
        Assert.NotNull(leitor);
        Assert.IsType<ClientesDoJson>(leitor);
    }

    [Fact]
    public void QuandoExtensaoJsonDeveRetornarTipoAdequado()
    {
        // arrange
        string caminhoDoArquivo = "qualquernome.json";

        // act
        var leitor = LeitorDeArquivoFactory.CreateLeitorDePets(caminhoDoArquivo);

        // assert
        Assert.NotNull(leitor);
        Assert.IsType<PetsDoJson>(leitor);
    }
}