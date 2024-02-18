using _03_06_XX_Enviando_Email.Console.Atributos;
using System.Reflection;

namespace _03_06_XX_Enviando_Email.Console.Util;

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