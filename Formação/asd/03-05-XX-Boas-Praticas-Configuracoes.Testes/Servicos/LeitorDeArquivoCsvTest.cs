using _03_05_XX_Boas_Praticas_Configuracoes.Console.Modelos;
using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Arquivos;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Testes.Servicos;

public class LeitorDeArquivoCsvTest : IDisposable
{
    private string caminhoArquivo;

    public LeitorDeArquivoCsvTest()
    {
        //Setup
        string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";
        File.WriteAllText("lista.csv", linha);
        caminhoArquivo = Path.GetFullPath("lista.csv");
    }

    [Fact]
    public void QuandoArquivoExistenteDeveRetornarUmaListaDePets()
    {
        //Arrange
        //Act
        var listaDePets = new PetsDoCsv(caminhoArquivo).RealizaLeitura()!;
        //Assert
        Assert.NotNull(listaDePets);
        Assert.Single(listaDePets);
        Assert.IsType<List<Pet>?>(listaDePets);
    }

    [Fact]
    public void QuandoArquivoNaoExistenteDeveRetornarNulo()
    {
        //Arrange
        //Act
        var listaDePets = new PetsDoCsv("").RealizaLeitura();
        //Assert
        Assert.Null(listaDePets);
    }

    [Fact]
    public void QuandoArquivoForNuloDeveRetornarNulo()
    {
        //Arrange
        //Act
        var listaDePets = new PetsDoCsv(null).RealizaLeitura();
        //Assert
        Assert.Null(listaDePets);
    }

    public void Dispose()
    {
        //ClearDown
        File.Delete(caminhoArquivo);
    }
}