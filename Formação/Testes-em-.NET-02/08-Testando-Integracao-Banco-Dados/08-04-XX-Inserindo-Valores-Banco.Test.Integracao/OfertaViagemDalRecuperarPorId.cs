using _08_04_XX_Inserindo_Valores_Banco.Dados;
using Xunit.Abstractions;

namespace _08_04_XX_Inserindo_Valores_Banco.Test.Integracao;

[Collection(nameof(ContextoCollection))]
public class OfertaViagemDalRecuperarPorId
{
    private readonly JornadaMilhasContext context;

    public OfertaViagemDalRecuperarPorId(ITestOutputHelper output, ContextoFixture fixture)
    {
        context = fixture.Context;
        output.WriteLine(context.GetHashCode().ToString());
    }

    [Fact]
    public void RetornaNuloQuandoIdInexistente()
    {
        //arrange
        var dal = new OfertaViagemDAL(context);

        //act
        var ofertaRecuperada = dal.RecuperarPorId(-2);

        //assert
        Assert.Null(ofertaRecuperada);
    }
}