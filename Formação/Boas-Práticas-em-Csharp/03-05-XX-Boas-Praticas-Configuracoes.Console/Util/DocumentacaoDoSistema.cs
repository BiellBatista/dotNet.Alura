using _03_05_XX_Boas_Praticas_Configuracoes.Console.Atributos;
using System.Reflection;

namespace _03_05_XX_Boas_Praticas_Configuracoes.Console.Util;

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