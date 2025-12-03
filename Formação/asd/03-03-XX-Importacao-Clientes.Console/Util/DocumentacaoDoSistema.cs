using _03_03_XX_Importacao_Clientes.Console.Atributos;
using System.Reflection;

namespace _03_03_XX_Importacao_Clientes.Console.Util;

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