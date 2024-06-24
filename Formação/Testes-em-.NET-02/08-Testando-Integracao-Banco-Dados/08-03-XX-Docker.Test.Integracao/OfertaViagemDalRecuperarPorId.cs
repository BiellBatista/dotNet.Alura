using _08_03_XX_Docker.Dados;
using Xunit.Abstractions;

namespace _08_03_XX_Docker.Test.Integracao;

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