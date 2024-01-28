using _01_XX_Declarando_Dependencias.Console.Comandos;
using System.Reflection;

namespace _01_XX_Declarando_Dependencias.Console.Util
{
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
}