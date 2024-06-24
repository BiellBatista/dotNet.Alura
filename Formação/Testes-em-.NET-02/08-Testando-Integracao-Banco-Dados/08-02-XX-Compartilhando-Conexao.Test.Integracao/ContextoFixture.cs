using _08_02_XX_Compartilhando_Conexao.Dados;
using Microsoft.EntityFrameworkCore;

namespace _08_02_XX_Compartilhando_Conexao.Test.Integracao;

public class ContextoFixture
{
    public JornadaMilhasContext Context { get; }

    public ContextoFixture()
    {
        var options = new DbContextOptionsBuilder<JornadaMilhasContext>()
            .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JornadaMilhas;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
            .Options;

        Context = new JornadaMilhasContext(options);
    }
}