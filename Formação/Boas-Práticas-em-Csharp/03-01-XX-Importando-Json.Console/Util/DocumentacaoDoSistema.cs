using _03_01_XX_Importando_Json.Console.Atributos;
using System.Reflection;

namespace _03_01_XX_Importando_Json.Console.Util;

public class DocumentacaoDoSistema
{
    public static Dictionary<string, DocComandoAttribute> ToDictionary(Assembly assemblyComOTipoDocComando)
    {
        return assemblyComOTipoDocComando.GetTypes()
         .Where(t => t.GetCustomAttributes<DocComandoAttribute>().Any())
         .Select(t => t.GetCustomAttribute<DocComandoAttribute>()!)
         .ToDictionary(d => d.Instrucao);
    }
}