using _08_05_XX_Revertendo_Ultimos_Testes.Dados;
using _08_05_XX_Revertendo_Ultimos_Testes.Modelos;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Testcontainers.MsSql;

namespace _08_05_XX_Revertendo_Ultimos_Testes.Test.Integracao;

public class ContextoFixture : IAsyncLifetime
{
    public JornadaMilhasContext Context { get; private set; }

    private readonly MsSqlContainer _msSqlContainer = new MsSqlBuilder()
        .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
        .Build();

    public async Task InitializeAsync()
    {
        await _msSqlContainer.StartAsync();
        var options = new DbContextOptionsBuilder<JornadaMilhasContext>()
            .UseSqlServer(_msSqlContainer.GetConnectionString())
            .Options;

        Context = new JornadaMilhasContext(options);
        Context.Database.Migrate();
    }

    public void CriaDadosFake()
    {
        Periodo periodo = new PeriodoDataBuilder().Build();

        var rota = new Rota("Curitiba", "São Paulo");

        var fakerOferta = new Faker<OfertaViagem>()
            .CustomInstantiator(f => new OfertaViagem(
                rota,
                new PeriodoDataBuilder().Build(),
                100 * f.Random.Int(1, 100))
            )
            .RuleFor(o => o.Desconto, f => 40)
            .RuleFor(o => o.Ativa, f => true);

        var lista = fakerOferta.Generate(200);
        Context.OfertasViagem.AddRange(lista);
        Context.SaveChanges();
    }

    public async Task LimpaDadosDoBanco()
    {
        /*        Context.OfertasViagem.RemoveRange(Context.OfertasViagem);
                Context.Rotas.RemoveRange(Context.Rotas);
                await Context.SaveChangesAsync();*/

        Context.Database.ExecuteSqlRaw("DELETE FROM OfertasViagem");
        Context.Database.ExecuteSqlRaw("DELETE FROM Rotas");
    }

    public async Task DisposeAsync()
    {
        await _msSqlContainer.StopAsync();
    }
}