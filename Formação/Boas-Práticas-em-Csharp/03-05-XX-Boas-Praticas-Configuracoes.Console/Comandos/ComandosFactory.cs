using _03_05_XX_Boas_Praticas_Configuracoes.Console.Extensions;
using System.Reflection;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Comandos;

public static class ComandosFactory
{
    public static IComando? CriarComando(string[] argumentos)
    {
        if (argumentos is null || argumentos.Length == 0)
        {
            return null;
        }
        var comando = argumentos[0];

        Type? tipoQueAtendeAInstrucao = Assembly
            .GetExecutingAssembly()
            .GetTipoDoComando(comando);

        if (tipoQueAtendeAInstrucao is null) return null;

        IEnumerable<IComandoFactory?> fabricasDeComandos = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            // filtre os tipos concretos que implementam IComandoFactory
            .Where(t => !t.IsInterface && t.IsAssignableTo(typeof(IComandoFactory)))
            // criar instâncias de cada fábrica (não é o ideal)
            .Select(f => Activator.CreateInstance(f) as IComandoFactory);

        // recuperar somente o responsável por criar o tipoQueAtendeAInstrucao
        IComandoFactory? fabrica = fabricasDeComandos
            .FirstOrDefault(f => f!.ConsegueCriarOTipo(tipoQueAtendeAInstrucao));

        if (fabrica is null) return null;
        return fabrica.CriarComando(argumentos);
    }
}