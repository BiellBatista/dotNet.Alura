using _03_05_XX_Boas_Praticas_Configuracoes.Console.Servicos.Arquivos;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Comandos.Show;

public class ShowFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(Show)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var leitorDeArquivosShow = LeitorDeArquivoFactory.CreateLeitorDePets(argumentos[1]);
        if (leitorDeArquivosShow is null) return null;
        return new Show(leitorDeArquivosShow);
    }
}