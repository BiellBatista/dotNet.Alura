using _08_02_XX_Compartilhando_Conexao.Dados;
using Xunit.Abstractions;

namespace _08_02_XX_Compartilhando_Conexao.Test.Integracao;

[Collection(nameof(ContextoCollection))]
public class OfertaViagemDalRecuperarTodas
{
    private readonly JornadaMilhasContext context;

    public OfertaViagemDalRecuperarTodas(ITestOutputHelper output, ContextoFixture fixture)
    {
        context = fixture.Context;
        output.WriteLine(context.GetHashCode().ToString());
    }
}