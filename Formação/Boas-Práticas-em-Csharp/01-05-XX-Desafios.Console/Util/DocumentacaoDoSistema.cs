using _01_05_XX_Desafios.Console.Comandos;
using System.Reflection;

namespace _01_05_XX_Desafios.Console.Util;

public class DocumentacaoDoSistema
{
    public static Dictionary<string, DocComando> ToDictionary(Assembly assemblyComOTipoDocComando)
    {
        return assemblyComOTipoDocComando.GetTypes()
            .Where(t => t.GetCustomAttributes<DocComando>().Any())
            .Select(t => t.GetCustomAttribute<DocComando>()!)
            .ToDictionary(d => d.Instrucao);
    }
}